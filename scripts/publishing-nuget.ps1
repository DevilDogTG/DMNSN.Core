# This script will help to build, pack and publish the NuGet package for the project.
# Receive param to check this build is on development (minor version) or production (major version).
param (
	[Parameter(Mandatory = $false)]
	[string]$buildType = "development" # development or production
)
# Configure
$rootPath = "${PSScriptRoot}\..\"
$projectName = "DMNSN.Core"
$projectPath = "${rootPath}\src\${projectName}\${projectName}.csproj"
##############################################################
# Under this line will be replace automatically when updated #
##############################################################
# Stopp script when an error occurs
$ErrorActionPreference = "Stop"

# Step 1: Checking all source has commit
Write-Host "Step 1: Checking if all source files have been committed..."
$uncommittedChanges = git status --porcelain
if ($uncommittedChanges) {
	Write-Host ".. There are uncommitted changes in the repository. Please commit or stash them before proceeding."
	exit 1
} else {
	Write-Host ".. All source files have been committed."
}

# Step 2: Restore and build the project
Write-Host "Step 2: Restoring and building the project..."
dotnet restore $projectPath
# If test exists run test before build
if (Test-Path "${rootPath}\tests\${projectName}.Tests\${projectName}.Tests.csproj") {
	Write-Host ".. Running tests..."
	dotnet test "${rootPath}\tests\${projectName}.Tests\${projectName}.Tests.csproj" --configuration Release
} else {
	Write-Host ".. No tests found, skipping test step."
}
Write-Host ".. Building the project..."
dotnet build $projectPath --configuration Release

# Step 3: Automatically running package version follow build type, if development running X.X.Y or production running X.Y.0
Write-Host "Step 3: Automatically updating package version...${buildType}"
# Create the package version based on the project file version, if project file version is not set, default to 8.0.0
$projectFile = [xml](Get-Content $projectPath)

# Find the Version element more robustly
$versionElement = $projectFile.SelectSingleNode("//Version")
if (-not $versionElement) {
	# Try alternative paths
	$versionElement = $projectFile.Project.PropertyGroup | ForEach-Object { $_.Version } | Where-Object { $_ } | Select-Object -First 1
}

$currentVersion = if ($versionElement) { 
	if ($versionElement.InnerText) { 
		$versionElement.InnerText 
	} elseif ($versionElement.'#text') { 
		$versionElement.'#text' 
	} else { 
		$null 
	}
} else { 
	$null 
}

if (-not $currentVersion -or $currentVersion.Trim() -eq "") {
	Write-Host ".. No version found in project file, setting default version to 8.0.0"
	$currentVersion = "8.0.0"
}
$versionParts = $currentVersion.Split('.')
if ($versionParts.Length -lt 3) {
	Write-Host ".. Invalid version format, setting default version to 8.0.0"
	$currentVersion = "8.0.0"
	$versionParts = $currentVersion.Split('.')
}
$majorVersion = $versionParts[0]
$minorVersion = $versionParts[1]
$patchVersion = $versionParts[2]
if ($buildType -eq "production") {
	Write-Host ".. Building for production, setting version to major.minor.0 and increase minor version"
	$minorVersion = [int]$minorVersion + 1
	$versionSuffix = "0"
} elseif ($buildType -eq "development") {
	Write-Host ".. Building for development, setting version to increase patch version"
	$versionSuffix = [int]$patchVersion + 1
} else {
	Write-Host ".. Invalid build type specified. Use 'development' or 'production'."
	exit 1
}
$newVersion = "$majorVersion.$minorVersion.$versionSuffix"
Write-Host ".. Setting package version to $newVersion"

# Update the project file with the new version - more robust approach
$versionElement = $projectFile.SelectSingleNode("//Version")
if (-not $versionElement) {
	# Try alternative approach to find version element
	$propertyGroups = $projectFile.Project.PropertyGroup
	foreach ($pg in $propertyGroups) {
		if ($pg.Version) {
			$versionElement = $pg.Version
			break
		}
	}
}

if ($versionElement) {
	Write-Host ".. Updating existing version element"
	$versionElement.InnerText = $newVersion
} else {
	Write-Host ".. Creating new version element"
	# Find the first PropertyGroup or create one
	$propertyGroup = $projectFile.Project.PropertyGroup | Select-Object -First 1
	if (-not $propertyGroup) {
		$propertyGroup = $projectFile.CreateElement("PropertyGroup")
		$projectFile.Project.AppendChild($propertyGroup)
	}
	
	# Create the Version element
	$versionNode = $projectFile.CreateElement("Version")
	$versionNode.InnerText = $newVersion
	$propertyGroup.AppendChild($versionNode)
}

# Save the updated project file
$projectFile.Save($projectPath)

# Step 4: Commit update version, if build type is production, also create tag for versioning
Write-Host "Step 4: Committing the updated version to the repository..."
git add $projectPath
if ($buildType -eq "production") {
	Write-Host ".. Creating a tag for the new version: v$newVersion"
	git commit -m "Bump version to $newVersion [skip ci]"
	git tag "v$newVersion"
} else {
	Write-Host ".. Committing the new version without tagging."
	git commit -m "Bump version to $newVersion [skip ci]"
}

# Step 5: Push changes to the repository
Write-Host "Step 5: Pushing changes to the repository..."
git push origin main
if ($buildType -eq "production") {
	Write-Host ".. Pushing the tag to the repository."
	git push origin "v$newVersion"
} else {
	Write-Host ".. No tag pushed for development build."
}

# Step 6: Pack the project into a NuGet package
Write-Host "Step 6: Packing the project into a NuGet package..."
dotnet pack $projectPath --configuration Release --output "${rootPath}\artifacts" --no-build

# Step 7: Publish the NuGet package
Write-Host "Step 7: Publishing the NuGet package..."
$packagePath = Get-ChildItem "${rootPath}\artifacts" -Filter "*.nupkg" | Sort-Object LastWriteTime -Descending | Select-Object -First 1
if ($packagePath) {
	Write-Host ".. Found package: $($packagePath.FullName)"
	dotnet nuget push $packagePath.FullName --source "https://api.nuget.org/v3/index.json"
	Write-Host ".. Package published successfully."
} else {
	Write-Host ".. No package found to publish."
	exit 1
}

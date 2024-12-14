& {

$TaskName = "ChangeWallpaperOnLogin"
$PicturesFolder = [Environment]::GetFolderPath('MyPictures')
$ScriptPath = "$PicturesFolder\ChangeWallpaper.ps1"  # Path to the wallpaper-changing script
$CurrentUser = [System.Security.Principal.WindowsIdentity]::GetCurrent().Name
$ErrorActionPreference = "Stop"  # Ensure the script stops on errors

# Check if the task already exists
if (Get-ScheduledTask -TaskName $TaskName -ErrorAction SilentlyContinue) {
    Write-Output "Task '$TaskName' already exists."
    return
}

# Ensure the script is running as administrator
$isAdmin = [Security.Principal.WindowsIdentity]::GetCurrent().Groups -contains 'S-1-5-32-544'
if (-not $isAdmin) {
    Write-Output "This script must be run as an administrator. Please restart it with administrative privileges."
    return
}

# Define the task action
$Action = New-ScheduledTaskAction -Execute 'PowerShell.exe' -Argument "-NoProfile -ExecutionPolicy Bypass -File `"$ScriptPath`""
# Create a logon trigger for the current user
$Trigger = New-ScheduledTaskTrigger -AtLogOn -User $CurrentUser

# Register the task
Register-ScheduledTask -TaskName $TaskName -Action $Action -Trigger $Trigger -Description "Runs the ChangeWallpaper script at user logon."
Write-Output "Scheduled task '$TaskName' has been created successfully."

}
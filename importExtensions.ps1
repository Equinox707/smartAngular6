foreach($line in Get-Content d:\smartAngular6\extensions.txt) {
    code --install-extension $line
}
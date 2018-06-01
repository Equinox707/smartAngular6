# Github Essentials

Init Git: `git init`

Add files to Git: `git add .`

Commit files: `git commit -m "Your message"`

Adding Remotes: `git remote add origin https://github.com/try-git/try_git.git`

Pull / Push from / to repository: `git pull / git push`

List Branches: `git branch -a`

Create a new Branch: `git checkout -b [name_of_your_new_branch]`

Push new Branch to remote: `git push origin [name_of_your_new_branch]`

Switch to Branch: `git checkout [name_of_your_branch]`

Merge Branch: `git merge [branch_to_merge]`

Checkout specifix Branch `git checkout -b <new_branch> <commit_sha>`

Merge Branch: `git merge [branch_to_merge]`

## Useful Github VS Code Extensions

[Git Lens](https://marketplace.visualstudio.com/items?itemName=eamodio.gitlens)

[Git History](https://marketplace.visualstudio.com/items?itemName=donjayamanne.githistory)

# Using VS Code

## VS Code Tips & Tricks

https://github.com/Microsoft/vscode-tips-and-tricks

https://zellwk.com/blog/useful-vscode-keyboard-shortcuts/

## Manage VS Code Extensions

#### Dump to File

```
code --list-extensions > d:\extensions.txt
```

#### Import using PowerShell - ie. importExtensions.ps1

```
foreach($line in Get-Content ".\extensions.txt") {
    code --install-extension $line
}
```

## Recommended VS Code Settings

```
{
    "workbench.startupEditor": "none",
    "workbench.colorTheme": "GitHub Plus",
    "terminal.integrated.shell.windows": "C:\\Windows\\System32\\WindowsPowerShell\\v1.0\\powershell.exe",
    "git.confirmSync": false,
    "git.enableSmartCommit": true,
    "git.autofetch": true,
    "vsicons.projectDetection.autoReload": true,
    "window.zoomLevel": 1,
    "problems.autoReveal": false,
    "workbench.editor.enablePreview": false,
    "editor.wordWrap": "on",
    "editor.minimap.enabled": false,
    "problems.decorations.enabled": false,
    "explorer.confirmDelete": false,
    "explorer.confirmDragAndDrop": false,
    "editor.formatOnSave": true,
    "gitlens.advanced.messages": {
        "suppressShowKeyBindingsNotice": true
    },
    "gitlens.historyExplorer.enabled": true,
    "gitlens.defaultDateStyle": "absolute",
    "css_peek.searchFileExtensions": [
        ".css",
        ".scss"
    ],
    "html-css-class-completion.enableEmmetSupport": true
}
```

## Debugging in VS Code using launch.json - .NET Core Projects

Add to .vscode -> launch.json

```{
    "version": "0.2.0",
    "configurations": [
        {
            "name": "ng serve",
            "type": "chrome",
            "request": "launch",
            "url": "http://localhost:4200/#",
            "webRoot": "${workspaceRoot}"
          },
          {
            "name": "ng test",
            "type": "chrome",
            "request": "launch",
            "url": "http://localhost:9876/debug.html",
            "webRoot": "${workspaceRoot}"
          },
          {
            "name": "ng e2e",
            "type": "node",
            "request": "launch",
            "program": "${workspaceRoot}/node_modules/protractor/bin/protractor",
            "protocol": "inspector",
            "args": ["${workspaceRoot}/protractor.conf.js"]
          }
    ]
}
```

# Markdown

Add your own Comments using Markdown

[Markdown Cheatsheet Intro](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet)

[Markdown Shorcuts - VS Code Extension](https://marketplace.visualstudio.com/items?itemName=mdickin.markdown-shortcuts)

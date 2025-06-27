[Setup]
AppName=IP Identifier
AppVersion=4.0
DefaultDirName={pf}\IP Identifier
DefaultGroupName=IP Identifier
OutputBaseFilename=IP Identifier Installer
Compression=lzma
SolidCompression=yes
SetupIconFile=C:\Users\###\###\IP Identifier V4\icon.ico
AllowNoIcons=no
DisableProgramGroupPage=no
AllowRootDirectory=yes

[Tasks]
Name: desktopicon; Description: "Create a &desktop icon"; GroupDescription: "Additional icons:"

[Files]
Source: "C:\Users\###\###\IP Identifier V4\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\IP Identifier"; Filename: "{app}\IP Identifier V4.exe"; IconFilename: "{app}\icon.ico"
Name: "{userdesktop}\IP Identifier"; Filename: "{app}\IP Identifier V4.exe"; IconFilename: "{app}\icon.ico"; Tasks: desktopicon

[Run]
Filename: "{app}\IP Identifier V4.exe"; Description: "Launch IP Identifier"; Flags: nowait postinstall skipifsilent

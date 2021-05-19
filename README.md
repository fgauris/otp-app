# HOTPKeyGeneratorApp

Generates HOTP keys


## How to set up:

1. Create new HOTP key using sha1.
2. Open HOTPKeyGeneratorApp\HOTPKeyGeneratorApp.dll.config file with text editor and paste HOTP seed to "Secret" appSetting. Seed will be in format 545EFDS..........AD2563.
3. Save and close HOTPKeyGeneratorApp.dll.config file.
4. Open HOTPKeyGeneratorApp.exe. App will go directly to system tray (next to clock) and will appear as key icon.
5. Right click key icon and click 'Generate'. Key will be copied to Clipboard.
6. Click Ctrl+V to paste the key.


## How app works:

New file 'counter.txt' is saved in %AppData%\HOTPKeyGeneratorApp. 
It will contain counter of how many times key was generated. Every new key generation will increase the counter. So, when new key is added, counter should be MANUALLY reset to 0 or file deleted.

# TwitchUnjail
Twitch vod downloader offering good speeds and low cpu utilization. Supports recovering vods using twitchtracker.com or streamscharts.com links.

Application can either be controlled via command line arguments or by entering data interactivly.

> Hint: CLI arguments have changed since RC3, please use the --url or --file argument !

# bcourtel's fork

Forked to use the Twitch GQL API. Dirty fix (I don't use .NET), see commits.

# Downloads

- [v1.0-rc6 windows x64](https://github.com/swent/twitch-unjail/releases/download/v1.0-rc6/twitch-unjail-1.0-rc6-win64.exe)
- [v1.0-rc6 linux x64](https://github.com/swent/twitch-unjail/releases/download/v1.0-rc6/twitch-unjail-1.0-rc6-linux64)
- [v1.0-rc6 osx x64](https://github.com/swent/twitch-unjail/releases/download/v1.0-rc6/twitch-unjail-1.0-rc6-osx64)

# Using command line arguments

Required arguments:
- `--url URL` the vod url to download
or
- `--file PATH` path to a file containing multiple vod-urls to download
or
- `--help` or `-h` prints all available cli arguments in the console window

Optional arguments:
- `--quality QUALITY` or `-q QUALITY` the quality setting used for the download (see quality section below), will default to `source` quality if not used
- `--name NAME` or `-n NAME` the download file name to use, will default to an auto-generated name if not used
- `--mbps SPEED` the megabyte(s) per second download speed to aim for (careful: NOT megabit/s), will default to unlimited if not used
- `--log` or `-l` enables very detailed process logging to a .log file in the download path, needed to report problems with the app
- `--output PATH` or `-o PATH` the path to download to (excluding filename), will default to current dir if not used

# Interactive mode

- Run the app
- It will ask to enter the vod url to download, enter/paste it and press enter
- It will query the available qualities (see quality section below), enter the desired quality and press enter
- It will ask for a download path (not filename), enter/paste it and press enter
- The app will now start downloading and print progress updates on screen

# Quality Settings

Settings that can be used in the app.
> Hint: `source` quality can be of any resolution or fps.

| Quality Setting | Short Form | Resolution | FPS   |
|-----------------|------------|------------|-------|
| AudioOnly       |            |            |       |
| 144p30          | 144p       | 256x144    | 30    |
| 160p30          | 160p       |            | 30    |
| 360p30          | 360p       | 640×360    | 30    |
| 360p60          |            | 640×360    | 60    |
| 480p30          | 480p       | 854x480    | 30    |
| 480p60          |            | 854x480    | 60    |
| 720p30          | 720p       | 1280x720   | 30    |
| 720p60          |            | 1280x720   | 60    |
| 1080p30         | 1080p      | 1920x1080  | 30    |
| 1080p60         |            | 1920x1080  | 60    |
| 1440p30         | 1440p      | 2560x1440  | 30    |
| 1440p60         |            | 2560x1440  | 60    |
| 4K30            | 4K30       | 3840x2160  | 30    |
| 4K60            |            | 3840x2160  | 60    |
| Source          |            | ?          | 30/60 |

# Run Examples

`twitch-unjail-1.0-rc6-win64.exe`

`twitch-unjail-1.0-rc6-win64.exe --url https://www.twitch.tv/videos/11111111`

`twitch-unjail-1.0-rc6-win64.exe --url https://www.twitch.tv/videos/11111111 --output C:\twitch`

`twitch-unjail-1.0-rc6-win64.exe --url https://www.twitch.tv/videos/11111111 -q 720p -o C:\twitch`

`twitch-unjail-1.0-rc6-win64.exe --url https://www.twitch.tv/videos/11111111 -mbps 7.5 -o C:\twitch`

`twitch-unjail-1.0-rc6-win64.exe --url https://www.twitch.tv/videos/11111111 --log`

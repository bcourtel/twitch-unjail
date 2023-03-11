echo "Enter version tag: "
read VERSION_TAG

dotnet publish TwitchUnjail.Cli/TwitchUnjail.Cli.csproj \
    --self-contained true \
    -p:PublishSingleFile=true \
    -p:PublishReadyToRun=true \
    --framework net7.0 \
    --runtime win-x64 \
    --configuration Release \
    --output publish/win-x64
dotnet publish TwitchUnjail.Cli/TwitchUnjail.Cli.csproj \
    --self-contained true \
    -p:PublishSingleFile=true \
    -p:PublishReadyToRun=true \
    --framework net7.0 \
    --runtime linux-x64 \
    --configuration Release \
    --output publish/linux-x64
dotnet publish TwitchUnjail.Cli/TwitchUnjail.Cli.csproj \
    --self-contained true \
    -p:PublishSingleFile=true \
    -p:PublishReadyToRun=true \
    --framework net7.0 \
    --runtime osx-x64 \
    --configuration Release \
    --output publish/osx-x64

cp publish/win-x64/TwitchUnjail.Cli.exe publish/twitch-unjail-${VERSION_TAG}-win64.exe
cp publish/linux-x64/TwitchUnjail.Cli publish/twitch-unjail-${VERSION_TAG}-linux64
cp publish/osx-x64/TwitchUnjail.Cli publish/twitch-unjail-${VERSION_TAG}-osx64

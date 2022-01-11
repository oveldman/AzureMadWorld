#!/bash/sh
convert_js_browser_compatible() {
    FOLDER="$1/*"

    for file in $FOLDER
    do
        convert_file $file
    done
}

convert_file() {
    OLD_FILENAME="$1"
    if [[ $1 != *".map"* ]] && [[ $1 != *"def.js"* ]]; then
        NEW_FILENAME="${OLD_FILENAME%.*}-def.js"
        echo "Convert" $OLD_FILENAME "->" $NEW_FILENAME
        browserify $OLD_FILENAME > $NEW_FILENAME
    fi
}

echo "Start the compile script"
cd ../MadWorld/MadWorld.Website/wwwroot/js
echo "Remove old javascript files"
rm -r base
rm -r extern
rm -r intern

echo "Build typescript"
cd ../typescript
tsc --build

echo "Start converting javascript files"
cd ../js
convert_js_browser_compatible base
convert_js_browser_compatible extern
convert_js_browser_compatible intern
echo "Script finished"




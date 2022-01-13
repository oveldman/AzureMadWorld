#!/bash/sh

# Visual Studio cannot find automatically the npm tools
add_tools_to_scope() {
    if [[ "$OSTYPE" == "darwin"* ]]; then
        # Mac OSX
        export PATH=/opt/homebrew/bin:$PATH
        export PATH=/usr/local/bin:$PATH
    else 
        # Other
        # User need to specify the folders for his OS
        exit 1
    fi
}

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
echo "Script executed from: ${PWD}"
echo "$OSTYPE"

START_FOLDER="../MadWorld/MadWorld.Website/wwwroot/js"
SCRIPT_TYPE="$1"

if [ $SCRIPT_TYPE == "C#" ]; then
    START_FOLDER="../../../wwwroot/js"
    add_tools_to_scope
fi

cd $START_FOLDER
echo "Remove old javascript files"
rm -r base/*
rm -r extern/*
rm -r intern/*

echo "Build typescript"
cd ../typescript
tsc --build

echo "Start converting javascript files"
cd ../js
convert_js_browser_compatible base
convert_js_browser_compatible extern
convert_js_browser_compatible intern
echo "Script finished"




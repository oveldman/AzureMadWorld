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

build_typescript() {
    echo "Build typescript"
    cd ../typescript
    tsc --build
}

check_if_pipeline() {
    if [ -z "$OSTYPE" ]; then
        echo "Exit script because pipeline"
        exit 0
    fi
}

convert_all_js_files() {
    echo "Start converting javascript files"
    cd ../js
    for js_folder in "${JS_FOLDERS[@]}"; do
        convert_js_browser_compatible $js_folder
    done
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

end_script() {
    echo "Script finished"
}

remove_old_javascript() {
    cd $START_FOLDER

    echo "Remove old javascript files"
    for js_folder in "${JS_FOLDERS[@]}"; do
        rm -r "${js_folder}/*" 
    done
}

start_script() {
    echo "Start the compile script"
    echo "Script executed from: ${PWD}"
}

start_script
check_if_pipeline

START_FOLDER="../MadWorld/MadWorld.Website/wwwroot/js"
SCRIPT_TYPE="$1"
JS_FOLDERS=("base" "extern" "intern")

if [ "$SCRIPT_TYPE" == "C#" ]; then
    START_FOLDER="../../../wwwroot/js"
    add_tools_to_scope
fi

remove_old_javascript
build_typescript
convert_all_js_files
end_script
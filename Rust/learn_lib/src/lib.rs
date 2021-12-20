mod helper;

use std::os::raw::c_char;

#[repr(C)]
pub struct TestStruct {    
    pub id: i32,
    pub answer: i32
}

#[repr(C)]
pub struct StringStruct {    
    pub id: i32,
    pub answer: *mut c_char
}

#[no_mangle]
pub extern "C" fn plus(x: i32, y: i32) -> i32 {
    x + y
}

#[no_mangle]
pub extern "C" fn test_struct_string() -> StringStruct {
    StringStruct {
        id: 1,
        answer: helper::c_to_string("Random answer")
    }
}


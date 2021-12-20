use std::ffi::CString;
use std::os::raw::c_char;

pub fn c_to_string(body: &str) -> *mut c_char {
    let s = CString::new(body).expect("CString::new failed!");
    s.into_raw()
}


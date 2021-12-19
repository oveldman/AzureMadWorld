pub mod math {
    #[no_mangle]
    // This is for a test
    pub extern "C" fn plus(x: i32, y: i32) -> i32 {
        x + y
    }
}

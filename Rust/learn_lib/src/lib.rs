pub mod math {
    #[no_mangle]
    pub extern "C" fn plus(x: i32, y: i32) -> i32 {
        x + y
    }
}

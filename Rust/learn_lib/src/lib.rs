pub mod math {
    #[repr(C)]
    pub struct TestStruct {    
        pub id: i32,
        pub answer: i32,
    }

    #[no_mangle]
    pub extern "C" fn plus(x: i32, y: i32) -> i32 {
        x + y
    }

    #[no_mangle]
    pub extern "C" fn test_struct_plus(x: i32, y: i32) -> TestStruct {
        let plus: i32 = x + y;

        TestStruct {
            id: 1,
            answer: plus
        }
    }
}

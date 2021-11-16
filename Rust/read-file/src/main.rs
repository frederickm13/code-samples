use std::fs;

fn main() {
    let file_name = "../test.txt";

    println!("Reading the file: {}", file_name);

    let file_content = fs::read_to_string(file_name)
        .expect("Failed to read the file");

    println!("\nFile contents:\n---------------\n{}\n", file_content);
}
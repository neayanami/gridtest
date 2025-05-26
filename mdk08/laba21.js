// 1
let num1_1 = 123;
let num2_1 = 4567;
let length1_1 = String(num1_1).length;
let length2_1 = String(num2_1).length;
console.log(" ", length1_1 + length2_1);

// 2
let str_2 = "abcde";
let num_2 = 2;
console.log(" ", str_2[num_2]);

// 3
let str_3 = "abcdef";
console.log(" ", str_3[str_3.length - 3]);

// 4
let str_4 = "12345";
let sum_4 = 0;
for (let char of str_4) {
  sum_4 += parseInt(char);
}
console.log(" ", sum_4);

// 5
let num_5 = 12345;
let reversed_5 = parseInt(String(num_5).split("").reverse().join(""));
console.log(" ", reversed_5);

// 6
let num_6 = 12345;
let product_6 = 1;
for (let char of String(num_6)) {
  product_6 *= parseInt(char);
}
console.log(" ", product_6);

// 7
let num_7 = 10;
num_7++;
num_7++;
num_7--;
alert(" " + num_7);

// 8
let age_8 = prompt("Сколько вам лет?");
alert("Ваш возраст: " + age_8);

// 9
let side_9 = parseFloat(prompt("Введите длину стороны квадрата:"));
let area_9 = side_9 * side_9;
alert("Площадь квадрата: " + area_9);

// 10
let side1_10 = parseFloat(prompt("Введите первую сторону прямоугольника:"));
let side2_10 = parseFloat(prompt("Введите вторую сторону прямоугольника:"));
let perimeter_10 = 2 * (side1_10 + side2_10);
alert("Периметр прямоугольника: " + perimeter_10);

// 11
console.log("Задача 11:");
for (let i_11 = 10; i_11 >= 1; i_11--) {
  console.log(i_11);
}

// 12
let tc_12 = 25; // Температура в Цельсиях
let tf_12 = (9 / 5) * tc_12 + 32;
alert(" " + tc_12 + "°C = " + tf_12 + "°F");

// 13
let a_13 = 5;
let b_13 = 10;
let s_13 = a_13 * b_13;
alert("Площадь прямоугольника: " + s_13);

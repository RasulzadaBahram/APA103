//1.Verilmis arrayde tekrarlanan reqemleri silmek ve tekrar reqemlerin sayini gostermek.
// let nums=[1,2,4,5,6,7,8,9,1,1,1,14,15]
// let count=0
// for(let i=0;i<nums.length;i++){
//     for(let j=i+1;j<nums.length;j++){
//         if(nums[i]==nums[j]){
//             count++
//             nums.splice(j,1)
//             j--
//         }
//     }
// }
// console.log("Tekrarlanan reqemlerin sayi:", count)


//2.Verilmis sozun polindrom olub olmadığını yoxlayan alqoritm yazmaq.
// let name="nigin"
// let reversedName=""
// for(let i=name.length-1;i>=0;i--){
//     reversedName+=name[i]
// }
// if(name===reversedName){
//     console.log("Soz polindromdur")
// }else{
//     console.log("Soz polindrom deyil")
// }

//3.Girilen ededin verilmis arreyde nece elementden kicik oldugunu yazan alqoritim.
// let nums = [1, 2, 4, 5, 6, 7, 8, 14, 15]
// let num = 5
// let count = 0
// for (let i = 0; i < nums.length; i++) {
//     if (nums[i] < num) {
//         count++
//     }
// }
// console.log(`Verilmis eded ${num} \n${count} elementden kicikdir`)


//4.Daxil edilen ededin Aboundant ve ya Deficient oldugunu yoxlayan algorithm.(Abundant ədəd öz müsbət bolenlerinin(ozunden basqa) cəmi özündən böyük olan müsbət tam ədədlərə deyilir. Eks halda Deficient eded olur. 12-Aboundant, 13- Deficient)
// let num = 13
// let count=0
// for (let i = 1; i < num; i++) {
//     if (num % i == 0) {
//         count += i
//     }
// }
// if (count > num) {
//     console.log(`${num} Aboundant ededdir`)
// }
// else{
//     console.log(`${num} Deficient ededdir`)
// }

//5.Array-in bütün elementlərini kvadrata yüksəldib yeni array qaytaran funksiya yazın.
let nums = [1, 2, 3, 4, 5]
function kvadrat(nums) {
    let kvadratArray = []
    for (let i = 0; i < nums.length; i++) {
        kvadratArray.push(nums[i] * nums[i])
    }
    return kvadratArray
}   
console.log(kvadrat(nums))
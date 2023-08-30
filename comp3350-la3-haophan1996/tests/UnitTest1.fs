namespace wit.comp3350

open NUnit.Framework
open wit.comp3350.la3

module TestHelper =
    let assertListEquals (actual: 'a list) (expected: 'a list) =
        Assert.That(actual, Is.EqualTo(expected), $"Expected: {expected}\n     But was: {actual}")

    let assertListEquivalent (actual: 'a list) (expected: 'a list) =
        let aSorted = List.sort actual
        let eSorted = List.sort expected
        Assert.That(aSorted, Is.EqualTo(eSorted), $"Expected: {eSorted}\n     But was: {aSorted}")


[<Timeout(400); OrderAttribute(1)>]
module TestDist =

    [<Test>]
    let testDistC_1000 () =
        let actual: (string * int) list = dist "COMP" [ 1000 ]
        TestHelper.assertListEquals actual [ ("COMP", 1000) ]

    [<Test>]
    let testDistC_1200 () =
        let actual: (string * int) list = dist "COMP" [ 1000; 1200 ]
        TestHelper.assertListEquals actual [ ("COMP", 1000); ("COMP", 1200) ]

    [<Test>]
    let testDistC_1250 () =
        let actual: (string * int) list = dist "COMP" [ 1000; 1200; 2500 ]

        TestHelper.assertListEquals
            actual
            [ ("COMP", 1000)
              ("COMP", 1200)
              ("COMP", 2500) ]

[<Timeout(400); OrderAttribute(2)>]
module TestPairs =

    [<Test>]
    let testPairsC_1000 () =
        let actual: (string * int) list = pairs [ "COMP" ] [ 1000 ]
        TestHelper.assertListEquivalent actual [ ("COMP", 1000) ]


    [<Test>]
    let testPairsCM_1000 () =
        let actual: (string * int) list = pairs [ "COMP"; "MATH" ] [ 1000 ]
        TestHelper.assertListEquivalent actual [ ("COMP", 1000); ("MATH", 1000) ]

    [<Test>]
    let testPairsCM_1100 () =
        let actual: (string * int) list = pairs [ "COMP"; "MATH" ] [ 1000; 1100 ]

        TestHelper.assertListEquivalent
            actual
            [ ("COMP", 1000)
              ("COMP", 1100)
              ("MATH", 1000)
              ("MATH", 1100) ]

    [<Test>]
    let testPairsCMP_1200 () =
        let actual: (string * int) list = pairs [ "COMP"; "MATH"; "PHIL" ] [ 1000; 1100; 1200  ]

        TestHelper.assertListEquivalent
            actual
            [ ("COMP", 1000)
              ("COMP", 1100)
              ("COMP", 1200)
              ("MATH", 1000)
              ("MATH", 1100)
              ("MATH", 1200)
              ("PHIL", 1000)
              ("PHIL", 1100)
              ("PHIL", 1200) ]

[<Timeout(400); OrderAttribute(3)>]
module TestInsert =

    [<Test>]
    let testInsert_29_7 () =
        let actual = insert [ 2; 9 ] 7
        TestHelper.assertListEquals actual [ 2; 7; 9 ]

    [<Test>]
    let testInsert_23_7 () =
        let actual = insert [ 2; 3 ] 7
        TestHelper.assertListEquals actual [ 2; 3; 7 ]

    [<Test>]
    let testInsert_14_7 () =
        let actual = insert [ 1; 4 ] 7
        TestHelper.assertListEquals actual [ 1; 4; 7 ]

    [<Test>]
    let testInsert_e_7 () =
        let actual = insert [] 7
        TestHelper.assertListEquals actual [ 7 ]

[<Timeout(400); OrderAttribute(4)>]
module TestInsertionSort =

    [<Test>]
    let testInsertionSort_297 () =
        let actual = insertionSort [ 2; 9; 7 ]
        TestHelper.assertListEquals actual [ 2; 7; 9 ]

    [<Test>]
    let testInsertionSort_941 () =
        let actual = insertionSort [ 9; 4; 1 ]
        TestHelper.assertListEquals actual [ 1; 4; 9 ]

    [<Test>]
    let testInsertionSort_S () =
        let actual = insertionSort [ 2 ]
        TestHelper.assertListEquals actual [ 2 ]

[<Timeout(400); OrderAttribute(5)>]
module TestFizzBuzz =

    [<Test>]
    let testFizzbuzz_1 () =
        let actual = fizzbuzz 1
        TestHelper.assertListEquals actual [ "1" ]

    [<Test>]
    let testFizzbuzz_3 () =
        let actual = fizzbuzz 3
        TestHelper.assertListEquals actual [ "1"; "2"; "fizz" ]

    [<Test>]
    let testFizzbuzz_4 () =
        let actual = fizzbuzz 4
        TestHelper.assertListEquals actual [ "1"; "2"; "fizz"; "4" ]

    [<Test>]
    let testFizzbuzz_5 () =
        let actual = fizzbuzz 5
        TestHelper.assertListEquals actual [ "1"; "2"; "fizz"; "4"; "buzz" ]

    [<Test>]
    let testFizzbuzz_6 () =
        let actual = fizzbuzz 6

        TestHelper.assertListEquals
            actual
            [ "1"
              "2"
              "fizz"
              "4"
              "buzz"
              "fizz" ]

    [<Test>]
    let testFizzbuzz_11 () =
        let actual = fizzbuzz 11

        let expected =
            [ "1"
              "2"
              "fizz"
              "4"
              "buzz"
              "fizz"
              "7"
              "8"
              "fizz"
              "buzz"
              "11" ]

        TestHelper.assertListEquals actual expected

    [<Test>]
    let testFizzbuzz_15 () =
        let actual = fizzbuzz 15

        let expected =
            [ "1"
              "2"
              "fizz"
              "4"
              "buzz"
              "fizz"
              "7"
              "8"
              "fizz"
              "buzz"
              "11"
              "fizz"
              "13"
              "14"
              "fizzbuzz" ]

        TestHelper.assertListEquals actual expected

    [<Test>]
    let testFizzbuzz_0 () =
        let actual = fizzbuzz 0
        Assert.That(actual, Is.Empty)

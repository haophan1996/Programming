namespace wit.comp3350

open NUnit.Framework
open wit.comp3350.la6

module TestHelper =
    let assertOptionIsNone (actual: option<'a>) =
        match actual with
        | None -> Assert.Pass()
        | _ -> Assert.Fail($"Expected: None\n     But was: {actual}")
        
    let assertOptionIsSome (actual: option<'a>) (expected: option<'a>) =
        match actual with
        | None -> Assert.Fail($"Expected: {expected}\n     But was: None")
        | _ -> Assert.That(actual, Is.EqualTo(expected))
        
    let assertListEquals (actual: 'a list) (expected: 'a list) =
        let fmt = sprintf "Expected: %A\n     But was: %A"
        Assert.That(actual, Is.EqualTo(expected), (fmt expected actual))

[<Timeout(400); OrderAttribute(1)>]
module TestReadRegex =
    [<Test>]
    let testA1 () =
        let strs = pA1Strs
        let rgx = pA1Regex
        let actual = strs |> List.distinct |> List.map rgx.IsMatch
        Assert.That(actual, Is.All.True)
        
    [<Test>]
    let testA2 () =
        let strs = pA2Strs
        let rgx = pA2Regex
        let actual = strs |> List.distinct |> List.map rgx.IsMatch
        Assert.That(actual, Is.All.True)
        
    [<Test>]
    let testA3 () =
        let strs = pA3Strs
        let rgx = pA3Regex
        let actual = strs |> List.distinct |> List.map rgx.IsMatch
        Assert.That(actual, Is.All.True)

[<Timeout(400); OrderAttribute(2)>]
module TestWriteRegex =
    [<Test>]
    let testB1YesRegex () =
        let strs = pB1YesStrs
        let rgx = pB1Regex
        let actual = strs |> List.distinct |> List.map rgx.IsMatch
        Assert.That(actual, Is.All.True)
        
    [<Test>]
    let testB1NoRegex () =
        let strs = pB1NoStrs
        let rgx = pB1Regex
        let actual = strs |> List.distinct |> List.map rgx.IsMatch
        Assert.That(actual, Is.All.False)
        
    [<Test>]
    let testB2YesRegex () =
        let strs = pB2YesStrs
        let rgx = pB2Regex
        let actual = strs |> List.distinct |> List.map rgx.IsMatch
        Assert.That(actual, Is.All.True)
        
    [<Test>]
    let testB2NoRegex () =
        let strs = pB2NoStrs
        let rgx = pB2Regex
        let actual = strs |> List.distinct |> List.map rgx.IsMatch
        Assert.That(actual, Is.All.False)
        
    [<Test>]
    let testB3YesRegex () =
        let strs = pB3YesStrs
        let rgx = pB3Regex
        let actual = strs |> List.distinct |> List.map rgx.IsMatch
        Assert.That(actual, Is.All.True)
        
    [<Test>]
    let testB3NoRegex () =
        let strs = pB3NoStrs
        let rgx = pB3Regex
        let actual = strs |> List.distinct |> List.map rgx.IsMatch
        Assert.That(actual, Is.All.False)
        
[<Timeout(400); OrderAttribute(3)>]
module TestKwTokens =
    [<Test>]
    let testTokenizeKwLet () =
        let actual = tokenize "let"
        Assert.That(actual, Is.EqualTo(Keyword "let"))

    [<Test>]
    let testTokenizeNonKwLet1 () =
        let actual = tokenize "letter"
        Assert.That(actual, Is.Not.EqualTo(Keyword "letter"))
        
    [<Test>]
    let testTokenizeNonKwLet2 () =
        let actual = tokenize "sublet"
        Assert.That(actual, Is.Not.EqualTo(Keyword "sublet"))

    [<Test>]
    let testTokenizeNonKwIf1 () =
        let actual = tokenize "iffy"
        Assert.That(actual, Is.Not.EqualTo(Keyword "iffy"))

    [<Test>]
    let testTokenizeNonKwIf2 () =
        let actual = tokenize "zeeif"
        Assert.That(actual, Is.Not.EqualTo(Keyword "zeeif"))
        
    [<Test>]
    let testTokenizeKwThen () =
        let actual = tokenize "then"
        Assert.That(actual, Is.EqualTo(Keyword "then"))

    [<Test>]
    let testTokenizeKwElse () =
        let actual = tokenize "else"
        Assert.That(actual, Is.EqualTo(Keyword "else"))
        
[<Timeout(400); OrderAttribute(4)>]
module TestIntNums =

    [<Test>]
    let testTokenizeIntNum42 () =
        let actual =  tokenize "42"
        Assert.That(actual, Is.EqualTo(IntNum 42))
        
    [<Test>]
    let testTokenizeIntNum9 () =
        let actual =  tokenize "9"
        Assert.That(actual, Is.EqualTo(IntNum 9))

    [<Test>]
    let testTokenizeIntNum0 () =
        let actual =  tokenize "0"
        Assert.That(actual, Is.EqualTo(IntNum 0))

    [<Test>]
    let testTokenizeIntNum_n7 () =
        let actual =  tokenize "-71"
        Assert.That(actual, Is.EqualTo(IntNum -71))
        
    [<Test>]
    let testTokenizeInvalIntNum () =
        let actual =  tokenize "007"
        Assert.That(actual, Is.EqualTo(Error "007"))

[<Timeout(400); OrderAttribute(5)>]
module TestFloatNums =
    [<Test>]
    let testTokenizeFloatNum1_1 () =
        let actual =  tokenize "1.1"
        Assert.That(actual, Is.EqualTo(FloatNum 1.1))
        
    [<Test>]
    let testTokenizeFloatNum0_2 () =
        let actual =  tokenize "0.2"
        Assert.That(actual, Is.EqualTo(FloatNum 0.2))

    [<Test>]
    let testTokenizeIntNum0 () =
        let actual =  tokenize "0.0"
        Assert.That(actual, Is.EqualTo(FloatNum 0.0))


[<Timeout(400); OrderAttribute(6)>]
module TestCode =

    [<Test>]
    let testTokenizeLetX42 () =
        let actual =  tokenizeAll "let x = 42"
        TestHelper.assertListEquals actual [Keyword "let"; Ident "x"; Assgn; IntNum 42]

    [<Test>]
    let testTokenizeLetX44_11 () =
        let actual =  tokenizeAll "let x1 = 44 + 11"
        TestHelper.assertListEquals actual [Keyword "let"; Ident "x1"; Assgn; IntNum 44; Op "+"; IntNum 11]
        
    [<Test>]
    let testTokenizeLetDist_x_lt_10 () =
        let actual =  tokenizeAll "let dist = if x < 10 then 1 else 0"
        TestHelper.assertListEquals actual [Keyword "let"; Ident "dist"; Assgn; Keyword "if"; Ident "x"; Op "<"; IntNum
        10; Keyword "then"; IntNum 1; Keyword "else"; IntNum 0]

namespace wit.comp3350

open System.Text.RegularExpressions

module la6 =

    /////////////////////// Part A
    // TODO: Complete below (no documentation needed)

    let pA1Regex = Regex @"ABC\d"
    let pA1Strs = [ "ABC7"; "ABC6"; "ABC5" ]

    let pA2Regex = Regex @"[a-f]+$"
    let pA2Strs = [ "abc1abc"; "abc2def"; "def-abc" ]

    let pA3Regex = Regex @"0\.(\d+)"
    let pA3Strs = [ "0.12"; "0.32"; "0.98" ]

    /////////////////////// Part B
    // TODO: Complete below (no documentation needed)

    let pB1Regex = Regex @"KZG|ZG"
    let pB1YesStrs = [ "KZG"; "ZG" ]
    let pB1NoStrs = [ "KZ G"; "KZ"; "kgz"; "gz" ]

    let pB2Regex = Regex @"^[0-9]$"
    let pB2YesStrs = [ "1"; "2"; "3" ]
    let pB2NoStrs = [ " 1"; "2 "; " 3 " ]
    
    let pB3Regex = Regex @"^(?!.*(i|aa|eb))"
    let pB3YesStrs = [ "apple"; "banana" ]
    let pB3NoStrs = [ "applepie"; "banana split"; "bananaapple"; "applebanana" ]

    /////////////////////// Part C.0
    /// <summary>A union type of all tokens the lexer is to generate</summary>
    type Token =
        | Assgn
        | Op of string
        | Keyword of string
        | Ident of string
        | IntNum of int
        | FloatNum of float
        | Error of string

    /////////////////////// Part C.1
    // TODO: Complete below (no documentation needed)
    // note: you need to also complete C.2 for each token type for the tests to work

    let kwRegex = Regex @"^(let|if|then|else)$"
    let idRegex = Regex @"^[a-z][0-9]?"
    let intNumRegex = Regex @"^-?[0-9]*$"
    let floatNumRegex = Regex @"^-?[0-9]\.[0-9]"

    /////////////////////// Part C.2
    // TODO: Complete below (no documentation needed)
    let tokenize (s: string) =
        if s = "=" then
            Assgn
        elif List.contains s [ "+"; "-"; "<"; ">" ] then
            Op s
        elif kwRegex.IsMatch s then
            Keyword s
        // TODO: Add more elifs below
        elif idRegex.IsMatch s then
            Ident s
        elif intNumRegex.IsMatch s then
            let num = int s 
            if num = 0 || not (s.StartsWith("0")) then 
                IntNum num
            else 
                Error s
        elif floatNumRegex.IsMatch s then
            FloatNum (float s)
        else
            Error s

    /// <summary>Convenience function that will call tokenize on the entire string</summary>
    /// <param name="str">The souce code to tokenize</param>
    /// <returns>List of tokens</returns>
    let tokenizeAll (str: string) =
        str.Split() |> Array.toList |> List.map tokenize

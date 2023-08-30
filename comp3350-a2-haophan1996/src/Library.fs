namespace wit.comp3350

module a2 =
    /// TODO: Complete and document
    /// case 1: empty, just return nothing, or 1 left element return as list with 1 element
    /// check if elm 1 equal to elm 2, so we call function again
    /// and if h not equal to tail head, so we add h and call function again
    let rec compress l =  
                    match l with
                    | [] -> [] 
                    | [_] -> l
                    | h::t when (h = t.Head ) -> compress t 
                    | h::t -> h :: compress t


    /// TODO: Complete and document
    /// case 1: base case, return empty tuple containing two empty list
    /// case 2: if head not equal to delim, so it will define var list and remainder of list,
    ///     and equal to recursive function, and then add head to to first list
    /// case 3: return remainder to support case 2
    let rec split1 chars delim = 
        match chars with
        | [] -> ([], [])
        | h::t when (h <> delim) ->
            let (list, rem) = split1 t delim
            (h::list, rem)
        | _::t -> ([], t)  
        

    /// TODO: Complete and document
    /// This I use pipeline, which is first i do filter if element in List match pred
    /// then return total element in list
    let count pred l = 
            l |> List.filter pred
              |> List.length 


    /// TODO: Complete and document
    /// case 1: base case, return empty string
    /// case 2: if tail is not empty, so head + delim + recursive function join with remainder list and delim
    /// case 3: return head
    let rec join l (d: string) =
        match l with
        | [] -> ""
        | h::t when (t <> []) -> h+d+ (join t d)
        | h::t -> h

    /// TODO: Complete and document
    /// compareStrings, this will compare 2element string in a list, 
    /// List.sortBy, this will sort all string in tuple, but the element inside list will not sort
    /// list.map this will sort elements in list, inside tuple
    let sortPairs (l: (string * string) list) =
        let compareStrings (s1: string) (s2: string) =
            let first, second =
                if s1.ToUpper() > s2.ToUpper() then 
                    (s2, s1)
                else 
                    (s1, s2)
            (first, second)

        l
        |> List.sortBy (fun (first, _) -> first.ToUpper())
        |> List.map (fun (fststring, sndstring) -> compareStrings fststring sndstring)
         

    /// Take a grid tuple and print it using printfn
    /// <param name="grid">The 4-tuple that contains the numbers</param>
    /// <returns>None</returns>
    let printGrid grid =
        let i11, i12, i21, i22 = grid
        printfn $"{i11} {i12}\n{i21} {i22}"

    /// TODO: Complete and document
    /// set a b c d equal to grid, and return horizontal format
    let flipHr grid =
        let a,b,c,d = grid
        (c, d, a, b)

    /// TODO: Complete and document
    /// set a b c d equal to grid, and return vertical format
    let flipVr grid =
        let a,b,c,d = grid
        (b,a,d,c)

    /// TODO: Complete and document
    /// case 1: if command equal h, call fliphr
    /// case 2: if command equal to v, call flipvr
    /// case 3: return default grid 
    let flip commands =
        let myflip grid commands = 
            match commands with
            | 'h' -> flipHr grid
            | 'v' -> flipVr grid
            | _ -> grid
        commands |> List.fold myflip (1,2,3,4)


    /// List of valid characters for Flipper
    let validChars = ['I'; 'O'; 'S'; 'H'; 'Z'; 'X'; 'N']
    
    /// TODO: Complete and document
    /// if char contain elemt in l, so return true/false
    let either (c: char) l =
        List.contains c l

    /// TODO: Complete and document
    /// helper case 1: base case , return true
    /// case 2: when call either function either head valid, if return true, then recusive helper func
    /// case 3: return false
    let rotatingLetters (l: char list) =
        // List.forall (fun c -> List.exists)
        let rec rotatinghelper lst = 
            match lst with
            | [] -> true 
            | h::t when (either h validChars) -> rotatinghelper t
            | h::t -> false
        
        rotatinghelper l


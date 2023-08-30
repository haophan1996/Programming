namespace WIT.COMP3350

module LA4 =
    type Shape =
        | Circle of int
        | Rectangle of int * int
    
    /// TODO: Complete and document
    /// check if tuple has 1 element
    let isCircle s =
        match s with
        | Circle _ -> true
        | Rectangle _-> false
 
    /// TODO: Complete and document
    /// check if two elemt in tuple, if so, return true if a equal b
    let isRectangle s =
        match s with
        | Circle _ -> false
        | Rectangle _-> true

    /// TODO: Complete and document
    /// check if a = b , return true, else false
    let isSquare s =
        match s with
        | Circle _ -> false
        | Rectangle (a,b) when (a = b) -> true
        | Rectangle _ -> false

    /// TODO: Complete and document
    /// case 1: basecase, empty return 0
    /// check match head element is circle, 1 + recursive function with tail
    /// case 3: recursive function tail
    let rec countCircles l =
        match l with
        | [] -> 0
        | h::t when (isCircle h) -> 1 + countCircles t
        | h::t -> countCircles t

    /// TODO: Complete and document
    /// To be done without the List module.
    /// case 1 : empty list, return none
    /// case 2
    ///     recursive function, if 
    ///         none then return head, 
    ///         if not, we comapre head and all number in tail
    let rec tryMin l =
        match l with 
        | [] -> None
        | h::t ->
            match tryMin t with
            | None -> Some h
            | Some m -> Some (min h m)


    /// TODO: Complete and document
    /// To be done without the List module.
    /// case 1: any number, empty list , so return none
    /// case 2: if index 0, and head and anynum, then return h
    /// case 3: index and any head tail , n will keep minus 1 by call recursive function
    let rec tryNth n l =
        match (n,l) with
        | (_,[]) -> None
        | (0, h::_) -> Some h
        | (n, _ :: t) -> tryNth (n-1) t

    /// TODO: Complete and document
    /// To be done without the List module.
    /// case 1: base if empty list, return empty list
    /// case 2: if head match pred then return index, else call function help with index + 1 and tail
    /// tryfindhelper will start index 0
    let rec tryFindIdx pred l =
        let rec tryfindhelper index rem = 
            match rem with
            | [] -> None
            | h::t ->
                if (pred h) then
                    Some index
                else
                    tryfindhelper (index + 1) t
        tryfindhelper 0 l

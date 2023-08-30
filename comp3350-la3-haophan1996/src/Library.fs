namespace wit.comp3350

module la3 =
    /// TODO: Complete and document 
    /// empty case, already ran
    /// take x and head into 1 pair then repeat call function untill list empty
    let rec dist x l =
        match l with
        | [] -> []
        | h :: t -> (x,h) :: dist x t 
    
    /// TODO: Complete and document 
    /// empty or already ran
    /// call dist and then combine into list and repeat call pair 
    let rec pairs l1 l2 =
        match l1 with
        | [] -> []
        | l1h :: l1t -> dist l1h l2 @ pairs l1t l2
       

    /// TODO: Complete and document
    /// base case, empty list or sorted, we return n
    /// second case: check if n less than head, then we do n and with l ( list)
    /// last: repeat call func tail and n
    let rec insert l n =
        match l with
        | [] -> [n]
        | h::t when (n < h) -> n :: l 
        | h::t -> h:: insert t n  
        

    /// TODO: Complete and document 
    /// base case: empty array, already sorted or empty
    /// repeat call function insert until the list is sorted
    let rec insertionSort l =
        match l with
        | [] -> []
        | h :: t -> insert (insertionSort t) h
         
        

    /// TODO: Complete and document
    /// so this i just do simple thing if else, 
    /// if n mod 3 equal 0 or else, they will print, if n cannot mod to 3 or 5 = 0, then 
    /// print n to string
    let fizzbuzzStr n =    
        match n with
        | n when (n % 3 = 0 && n % 5 = 0) -> "fizzbuzz"
        | n when (n % 5 = 0) -> "buzz"
        | n when (n % 3 = 0) -> "fizz"
        | n -> string n

    /// TODO: Complete and document
    /// base case is 1
    /// [fizzbuzzStr n] this will be the hightest if n = 5, so [fizzbuzzStr n] will be the last in the array
    /// then everything will be behind , so by that way it will make/go from lowest number to highest
    let rec fizzbuzz n = 
        // match n with
        // | 1 -> [fizzbuzzStr n]  
        // | _ -> 
        //     fizzbuzz (n - 1) @ [fizzbuzzStr n]  

        if n > 0 then
            fizzbuzz (n-1) @ [fizzbuzzStr n]
        else
            []
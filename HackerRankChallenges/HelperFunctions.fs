
module HelperFunctions

/// Rotates a list by one place forward.
let rotate lst =
    List.tail lst @ [List.head lst]

/// Gets all rotations of a list.
let getRotations lst =
    let rec getAll lst i = if i = 0 then [] else lst :: (getAll (rotate lst) (i - 1))
    getAll lst (List.length lst)

/// Gets all permutations (without repetition) of specified length from a list.
let rec getPerms n lst = 
    match n, lst with
    | 0, _ -> seq [[]]
    | _, [] -> seq []
    | k, _ -> lst |> getRotations |> Seq.collect (fun r -> Seq.map ((@) [List.head r]) (getPerms (k - 1) (List.tail r)))

/// Gets all permutations (with repetition) of specified length from a list.
let rec getPermsWithRep n lst = 
    match n, lst with
    | 0, _ -> seq [[]]
    | _, [] -> seq []
    | k, _ -> lst |> Seq.collect (fun x -> Seq.map ((@) [x]) (getPermsWithRep (k - 1) lst))
    // equivalent: | k, _ -> lst |> getRotations |> Seq.collect (fun r -> List.map ((@) [List.head r]) (getPermsWithRep (k - 1) r))

/// Gets all combinations (without repetition) of specified length from a list.
let rec getCombs n lst = 
    match n, lst with
    | 0, _ -> seq [[]]
    | _, [] -> seq []
    | k, (x :: xs) -> Seq.append (Seq.map ((@) [x]) (getCombs (k - 1) xs)) (getCombs k xs)

/// Gets all combinations (with repetition) of specified length from a list.
let rec getCombsWithRep n lst = 
    match n, lst with
    | 0, _ -> seq [[]]
    | _, [] -> seq []
    | k, (x :: xs) -> Seq.append (Seq.map ((@) [x]) (getCombsWithRep (k - 1) lst)) (getCombsWithRep k xs)


let sumUntil l target =
    let mutable sum = 0
    for item in l do
        if (sum + item <= target) then
            sum <- sum + item
    sum
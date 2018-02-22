namespace FSharpKoans

open NUnit.Framework

(*
Lists are immutable, ordered, finite sequences of a single type. compared to tuples that take multiple tuples
*)

module ``05: I Have Here In My Hand A List`` = 
    [<Test>]
    let ``01 Creating a list (Syntax 1).`` () = 
        let myList = ["apple"; "grape"; "pear"; "biscuit" ]
        myList |> should equal [ "apple"; "grape"; "pear"; "biscuit" ]
   
    [<Test>]
    let ``02 Creating a list (Syntax 2).`` () =
        let myList = "apple"::"grape"::"pear"::"biscuit"::[]          //add start of the list, so the first data is apple
        let myOtherList = "orange"::"lemon"::"princess"::["queen"]   // queen is already in the list, the first is orange then the last is queen
        let myNextList = "lily"::"sunflower"::"daisy"::["carrot"] // you may use [ and ] symbols on this line.
        let myLastList = "naartjie"::"raisin"::"apple"::"grape"::"pear"::"biscuit"::[] // DO NOT use [ or ] symbols on this line!
        myList |> should equal [ "apple"; "grape"; "pear"; "biscuit" ]
        myOtherList |> should equal [ "orange"; "lemon"; "princess"; "queen" ]
        myNextList |> should equal ["lily"; "sunflower"; "daisy"; "carrot"]
        myLastList |> should equal [ "naartjie"; "raisin"; "apple"; "grape"; "pear"; "biscuit" ]

    [<Test>]
    let ``03 Creating a list (via concatenation).`` () =
        let a = [902; 10]
        let b = [3; 13; 37]
        let result = a @ b    //order is important 
        result |> should equal [902; 10; 3; 13; 37]

    [<Test>]
    let ``04 The : : symbol (called "cons") does not modify an existing list`` () =  //cons adds to an existing list
        let first = [ "grape"; "peach" ]
        let second = "pear" :: first
        let third = "apple" :: second
        third |> should equal ["apple"; "pear" ; "grape"; "peach" ] //cannot do this ["pear" :: first]
        second |> should equal  [ "pear" ; "grape"; "peach" ]
        first |> should equal [ "grape"; "peach" ]

    [<Test>]
    let ``05 Pattern-matching a list (Part 1).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]  //list has a head and a tail
        let a::_ = fruits                            // a and wildcard. Wildcard does not return anything. 
        a |> should equal "apple"                    // a takes the head and the wildcard matches the rest of the list 

    [<Test>]
    let ``06 Pattern-matching a list (Part 2).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let b::c::_ = fruits
        b |> should equal "apple"
        c |> should equal "peach"

    [<Test>]
    let ``07 Pattern-matching a list (Part 3).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let _::d::e = fruits
        d |> should equal "peach"     //take the head 
        e |> should equal  [ "orange"; "watermelon"; "pineapple"; "tomato"]   //take the rest of the list

    [<Test>]
    let ``08 Pattern-matching a list (Part 4).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let f::_::_::g::_ = fruits
        f |> should equal "apple"
        g |> should equal "watermelon" // does not include the rest of the list because of the wildcard. 

    [<Test>]
    let ``09 Pattern-matching a list (Part 5).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let _::_::_::h = fruits
        h |> should equal [ "watermelon"; "pineapple"; "tomato"]

    [<Test>]
    let ``10 Pattern-matching a list (Part 6).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let [i;j;k;l;m;n] = fruits
        i |> should equal "apple"
        j |> should equal "peach"
        k |> should equal "orange"
        l |> should equal "watermelon"
        m |> should equal"pineapple"
        n |> should equal  "tomato"

    [<Test>]
    let ``11 Pattern-matching a list (Part 7).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let _::o::_::[p;q;r] = fruits
        o |> should equal  "peach"
        p |> should equal "watermelon"
        q |> should equal "pineapple"
        r |> should equal  "tomato"

    [<Test>]
    let ``12 Pattern-matching a list (Part 8).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let [_;s;_;_;t;_] = fruits
        s |> should equal "peach"
        t |> should equal "pineapple"

    [<Test>]
    let ``13 Pattern-matching a list (Part 9).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let k =
            match fruits with
            | [a;b;c;d;e] -> "prune"
            | _::t::_::u::_ -> t + u
            | _ -> "fig"
        k |> should equal "peachwatermelon"

    [<Test>]
    let ``14 Creating a list containing a sequence of numbers, and indexing`` () =
        let k = [6..50]        // sequential till 50
        let l = [3..3..20]    // sequence with a difference in 3 until 20
        k.[3] |> should equal 9  //.[3] which index position that considers index 0  
        l.[3] |> should equal 12
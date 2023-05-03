//Shows and hides the serchbar.
function expand() {
    if (document.getElementById("navbar-search").className.includes("search-expanded")) {
        document.getElementById("navbar-search").classList.remove("search-expanded");
    }
    else {
        document.getElementById("navbar-search").classList.add("search-expanded");
    }
    
}

//Takes the url parameters and sets the breadcrumb.
function SetBreadcrumb() {
    const list = window.location.href.split("/")
    for (var i = 0; i < list.length; i++) {
        list[i] = list[i].charAt(0).toUpperCase() + list[i].slice(1)
    }
    list.shift()
    list.shift()
    list.shift()
    

    var currentPage = ""
    for (var i = 0; i < list.length; i++) {
        currentPage = currentPage + " " + list[i]
    }
    try {
        document.getElementById("breadcrumb").innerHTML = currentPage
    } catch { }  
}
SetBreadcrumb()


//Function to set the active page on the navbar
function SetActivePageColour() {
    const query = window.location.href.split("/")
    try {
        document.getElementById(query[3]).classList.add("active")
    }
    console.log(query)
}
/*SetActivePageColour()*/


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

    var currentPage
    for (var i = 0; i < list.length; i++) {
        currentPage = currentPage + " " + list[i]
    }
    document.getElementById("breadcrumb").innerHTML = currentPage
}

SetBreadcrumb()



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


//Validate section

//Validates FirstName
function ValidateFirstName() {
    var input_value = document.getElementById("FormFirstName").value;
    if (input_value.length < 2) {
        document.getElementById("FirstNameError").innerHTML = "First name must contain atleast 2 characters"
    }
    else {
        document.getElementById("FirstNameError").innerHTML = ""
    }
}
//Validates LastName
function ValidateLastName() {
    var input_value = document.getElementById("FormLastName").value;
    if (input_value.length < 2) {
        document.getElementById("LastNameError").innerHTML = "Lastname must contain atleast 2 characters"
    }
    else {
        document.getElementById("LastNameError").innerHTML = ""
    }
}
//Validates PostalCode
function ValidatePostalCode() {
    var input_value = document.getElementById("FormPostalCode").value;
    if (/^[0-9]*$/.test(input_value) && input_value.length == 5) {
        document.getElementById("PostalCodeError").innerHTML = ""
    }
    else {
        document.getElementById("PostalCodeError").innerHTML = "The postal code must contain 5 numbers"
    }
}

//Validates Email
function ValidateEmail() {
    var input_value = document.getElementById("FormEmail").value;
    var regex_email = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
    if (regex_email.test(input_value)) {
        document.getElementById("EmailError").innerHTML = ""
    }
    else {
        document.getElementById("EmailError").innerHTML = "Please fill in a valid email"
    }
}

//Validates Password
function ValidatePassword() {
    var input_value = document.getElementById("FormPassword").value;

    //Checks so there is atleast one lowercase letter
    if (!/[a-z]/.test(input_value)) {
        document.getElementById("PasswordLowerCharacterErrorMessage").innerHTML = "The password must contain atleast one lowercase letter"
        document.getElementById("PasswordLowerCharacterError").classList.remove("d-none")
    }
    else {
        document.getElementById("PasswordLowerCharacterErrorMessage").innerHTML = ""
        document.getElementById("PasswordLowerCharacterError").classList.add("d-none")
    }

    //Checks so there is atleast one uppercase letter
    if (!/[A-Z]/.test(input_value)) {
        document.getElementById("PasswordUpperCharacterErrorMessage").innerHTML = "The password must contain atleast one uppercase letter"
        document.getElementById("PasswordUpperCharacterError").classList.remove("d-none")
    }
    else {
        document.getElementById("PasswordUpperCharacterErrorMessage").innerHTML = ""
        document.getElementById("PasswordUpperCharacterError").classList.add("d-none")
    }

    //Checks so there is atleast one special character
    if (!/[?!]/.test(input_value)) {
        document.getElementById("PasswordSpecialCharacterErrorMessage").innerHTML = "The password must contain atleast one special character"
        document.getElementById("PasswordSpecialCharacterError").classList.remove("d-none")
    }
    else {
        document.getElementById("PasswordSpecialCharacterErrorMessage").innerHTML = ""
        document.getElementById("PasswordSpecialCharacterError").classList.add("d-none")
    }

    //Checks so there is atleast one number
    if (!/[0-9]/.test(input_value)) {
        document.getElementById("PasswordNumberErrorMessage").innerHTML = "The password must contain atleast one number"
        document.getElementById("PasswordNumberError").classList.remove("d-none")
    }
    else {
        document.getElementById("PasswordNumberErrorMessage").innerHTML = ""
        document.getElementById("PasswordNumberError").classList.add("d-none")
    }

    //Checks so there is atleast 8 characters
    if (input_value.length < 8) {
        document.getElementById("PasswordLengthErrorMessage").innerHTML = "The password must contain atleast 8 characters in total"
        document.getElementById("PasswordLengthError").classList.remove("d-none")
    }
    else {
        document.getElementById("PasswordLengthErrorMessage").innerHTML = ""
        document.getElementById("PasswordLengthError").classList.add("d-none")
    }

}
//Validates Confirm Password
function ValidateConfirmPassword() {
    var confirmpassword = document.getElementById("FormConfirmPassword").value;
    var password = document.getElementById("FormPassword").value;

    if (confirmpassword !== password) {
        document.getElementById("ConfirmPasswordError").innerHTML = "The passwords do not match"
    }
    else {
        document.getElementById("ConfirmPasswordError").innerHTML = ""
    }
}


//Product details page image selector
function SetMainImage() {
    document.getElementById("detailsMainImage").src = event.target.src
}

//Details page increase or decrease buttons
function IncreaseAmount() {
    var currentquantity = parseInt(document.getElementById("productquantityselector").innerText)
    currentquantity++
    document.getElementById("productquantityselector").innerHTML = currentquantity
}
function DecreaseAmount() {
    var currentquantity = parseInt(document.getElementById("productquantityselector").innerText)
    if (currentquantity > 0) 
        currentquantity--
    document.getElementById("productquantityselector").innerHTML = currentquantity
}



/* if student is placed package and company field is visible*/
function displayfields() {
    var checkbox = document.getElementById("IsPlaced");
    var packages = document.getElementById("packages");
    var company = document.getElementById("company");
    if(checkbox.checked)
    {
        packages.style.display = "block";
        company.style.display = "block";
    }
    else
    {
        packages.style.display = "none";
        company.style.display = "none";
    }
}

function enable(Id){
    document.getElementById(Id).removeAttribute("readonly");
    
}
function enablebtn(){
    document.getElementById("submit-btn").style.display = "block";
}


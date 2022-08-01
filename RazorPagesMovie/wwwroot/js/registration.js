function recaptchaCallback() {
    //$('#submitBtn').removeAttr('disabled');
    document.getElementById("registrationSubmit").removeAttribute("disabled");
    document.getElementById("registrationErrorMsg").innerHTML = "";
};
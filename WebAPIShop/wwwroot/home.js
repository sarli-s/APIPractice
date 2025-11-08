const userEmail = document.querySelector("#userName")
const firstName = document.querySelector("#firstName")
const lastName = document.querySelector("#lastName")
const password = document.querySelector("#password")
function validateEmail(email) {
    return email.includes("@") && email.includes(".");
}

const register = async () => {
    try {
        if (!validateEmail(userEmail.value)) {
            alert("כתובת האימייל אינה תקינה");
            return;
        }

        if (password.value.length < 4 || password.value.length > 8) {
            alert("הסיסמה חייבת להיות בין 4 ל-8 תווים");
            return;
        }
        const newUser = {
            UserId: 0,
            UserEmail: userEmail.value,
            UserFirstName: firstName.value,
            UserLastName: lastName.value,
            UserPassword: password.value
        }
        const response = await fetch('https://localhost:44324/api/Users', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newUser)
        });
        if (response.ok) {
            const dataPost = await response.json();

            alert("💕 נרשמת בהצלחה")
        }
        else {
            alert(" 😒 מצטערים, הרשמתך לא נקלטה")
        }
    } catch (err) {
        alert(err)
    }
}



const loginUserEmail = document.querySelector("#userNameR")
const loginUserPassword = document.querySelector("#passwordR")

const login = async () => {
    try {
        const loginUser = {
            LoginUserEmail: loginUserEmail.value,
            LoginUserPassword: loginUserPassword.value
        }
        const response = await fetch('https://localhost:44324/api/Users/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(loginUser)
        });
        if (response.status == 204) {   /////
            alert(" 😒 אתה עדייין לא קיים במערכת נא הרשם")
        }

        else {
            alert("💕  התחברת בהצלחה")
            const currentUser = await response.json();
            sessionStorage.setItem("currentUser", JSON.stringify(currentUser))
            window.location.href = "update.html"
        }
    } catch (err) {
        alert(err)
    }


}



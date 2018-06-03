var modal = document.getElementById('myModal');
var span = document.getElementsByClassName("close")[0];
var demo = document.getElementById("demo");

span.onclick = function () {
    modal.style.display = "none";
}
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}

function check1() { //가입
    if (form1.email.value == "") {
        demo.innerText = "이메일을 입력하세요";
        modal.style.display = "block";
        return 0;
    }
    var regExp = /[0-9a-zA-Z][_0-9a-zA-Z-]*@[_0-9a-zA-Z-]+(\.[_0-9a-zA-Z-]+){1,2}$/;

    if (!form1.email.value.match(regExp)) {
        demo.innerText = "이메일의 형식을 지켜주세요";
        modal.style.display = "block";
        return 0;
    }

    if (form1.nickname.value == "") {
        demo.innerText = "닉네임을 입력하세요";
        modal.style.display = "block";
        return 0;
    }
    if (form1.pw.value == "") {
        demo.innerText = "비밀번호를 입력하세요";
        modal.style.display = "block";
        return 0;
    }
    if (form1.pw_check.value == "") {
        demo.innerText = "비밀번호 재입력을 입력하세요";
        modal.style.display = "block";
        return 0;
    }
    if (form1.pw.value != form1.pw_check.value) {
        demo.innerText = "비밀번호가 일치하지 않습니다.";
        modal.style.display = "block";
        return;
    }
    form1.submit();
}

function check2() { //로그인
    if (form2.email.value == "") {
        demo.innerText = "이메일을 입력하세요";
        modal.style.display = "block";
        return 0;
    }
    var regExp = /[0-9a-zA-Z][_0-9a-zA-Z-]*@[_0-9a-zA-Z-]+(\.[_0-9a-zA-Z-]+){1,2}$/;

    if (!form2.email.value.match(regExp)) {
        demo.innerText = "이메일의 형식을 지켜주세요";
        modal.style.display = "block";
        return 0;
    }

    if (form2.pw.value == "") {
        demo.innerText = "비밀번호를 입력하세요";
        modal.style.display = "block";
        return 0;
    }
    form2.submit();
}

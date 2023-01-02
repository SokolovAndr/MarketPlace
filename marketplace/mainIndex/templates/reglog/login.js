const reqLogin = (url) => {
    let login = document.getElementsByName('email');
    let password = document.getElementsByName('pass');
    let xhr = new XMLHttpRequest();
    xhr.open('POST', '../api/login', false)
    let request = {'username':login,'password':password}
    xhr.send(JSON.stringify(request))
    if (xhr.status == 401) {
        document.getElementsByName('email') = ''
        document.getElementsByName('pass') = ''
    }
    else {
        window.location.href = document.getElementsById('__url')
    }
}
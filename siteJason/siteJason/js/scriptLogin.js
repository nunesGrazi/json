const txtLogin = document.querySelector("#txtLogin");
const txtSenha = document.querySelector("#txtSenha");

const mensagem = document.querySelector(".mensagem");
const textoMensagem = document.querySelector("#mensagemTexto");

const BotaoLogin = document.querySelector("#btnEntrar");

if (BotaoLogin) {
    BotaoLogin.addEventListener('click', function(e) {
        e.preventDefault();

        txtLogin.setAttribute("disabled", true);
        txtSenha.setAttribute("disabled", true);
        this.setAttribute("disabled", true);
        this.innerHTML = "<span class='material-symbols-outlined'>hourglass_empty</span>Aguarde...";


        if (txtLogin.value == "") {
            textoMensagem.innerHTML = "Login deve ser digitado";
            mensagem.classList.remove("escondido");

            txtLogin.removeAttribute("disabled");
            txtSenha.removeAttribute("disabled");
            BotaoLogin.removeAttribute("disabled");
            BotaoLogin.innerHTML = "<span class='material-symbols-outlined'>Login</span>Entrar";
            return;
        }

        if (txtSenha.value == "") {
            textoMensagem.innerHTML = "Senha deve ser digitada";
            mensagem.classList.remove("escondido");

            txtLogin.removeAttribute("disabled");
            txtSenha.removeAttribute("disabled");
            BotaoLogin.removeAttribute("disabled");
            BotaoLogin.innerHTML = "<span class='material-symbols-outlined'>Login</span>Entrar";
            return;
        }

        const formData = new FormData;
        formData.append("login", txtLogin.value);
        formData.append("senha", txtSenha.value);

        fetch('biblioteca/acessar.aspx', {
            method: 'post',
            body: formData
        })
            .then(function (response) {
                return response.json();
            })
            .then(function (data) {
                //Colocar o "login ou senha invalido.";
                console.log(data);
            })
            .catch(function (error) {
                console.error('Erro ao buscar os dados:', error);
            }); 
    })
}
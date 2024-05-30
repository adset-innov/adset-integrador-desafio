function Pagina() {
    let dataTable;

    function dataTableFill(statusPagination, select, data, currentPage) {
        if (!data?.Dados) {
            return;
        }

        const count = (currentPage * select.value) - select.value;
        const delimiter = count + data.Dados.length;

        dataTable.fill(data.Total, delimiter, data.Dados, 'previous', 'next');

        Array.from(document.getElementById("tableVeiculo").rows).forEach((tr, index) => {
            const id = data.Dados[index].Id;
        });


        statusPagination.innerText = `${(delimiter > 0) ? count + 1 : 0}-${delimiter} de ${data.Total}`;
    }

    async function changePage(statusPagination, select) {
        loadingDataTable(true);

        setupRequest(dataTable.getCurrentPage(), select.value);
        
        let url = new URL(window.location);
        let params = new URLSearchParams(url.search);

        let data = await getVeiculo(params);

        dataTable.setCurrentPage(params.get('pagina'));
        dataTableFill(statusPagination, select, data, dataTable.getCurrentPage());

        loadingDataTable(false);
    }

    function cadastrarVeiculo() {
        window.location.href = '/CadastrarVeiculo/Cadastrar';
    }

    async function getVeiculo(params) {
        try {
            const { data: response } = await axios.get('/api/Veiculo/GetVeiculoByFilter', { params: params })
            return response
        }
        catch (error) {
            console.log(error);
        }
    }

    function setUrlParam(key, value) {
        if (history.pushState) {
            let searchParams = new URLSearchParams(window.location.search);
            searchParams.set(key, value);
            let newurl = window.location.protocol + "//" + window.location.host + window.location.pathname + '?' + searchParams.toString();
            window.history.pushState({ path: newurl }, '', newurl);
        }
    }

    function appendUrlParam(key, value) {
        if (history.pushState) {
            let searchParams = new URLSearchParams(window.location.search);
            searchParams.append(key, value);
            let newurl = window.location.protocol + "//" + window.location.host + window.location.pathname + '?' + searchParams.toString();
            window.history.pushState({ path: newurl }, '', newurl);
        }
    }

    function removeUrlParameter(paramKey) {
        const url = window.location.href
        var r = new URL(url)
        r.searchParams.delete(paramKey)
        const newUrl = r.href
        window.history.pushState({ path: newUrl }, '', newUrl)
    }

    function setupRequest(page, countPage) {
        let oldSearchParams = new URLSearchParams(window.location.search);

        setUrlParam("quantidadePorPagina", countPage);

        let consultaPlaca = document.getElementById("consultaPlaca").value;
        let consultaMarca = document.getElementById("consultaMarca").value;
        let consultaModelo = document.getElementById("consultaModelo").value;
        let consultaAnoMin = document.getElementById("consultaAnoMin").value;
        let consultaAnoMax = document.getElementById("consultaAnoMax").value;
        let consultaPreco = document.getElementById("consultaPreco").value;
        let consultaFoto = document.getElementById("consultaFoto").value;
        let consultaOpcional = document.getElementById("consultaOpcional").value;
        let consultaCor = document.getElementById("consultaCor").value;

        setUrlParam("Placa", consultaPlaca);
        setUrlParam("Marca", consultaMarca);
        setUrlParam("Modelo", consultaModelo);
        setUrlParam("AnoMin", consultaAnoMin);
        setUrlParam("AnoMax", consultaAnoMax);
        setUrlParam("Preco", consultaPreco);
        setUrlParam("Fotos", consultaFoto);
        setUrlParam("Opcional", consultaOpcional);
        setUrlParam("Cor", consultaCor);

        //toda vez que for configurar os filtros, é necessário ir para primeira página
        let newSearchParams = new URLSearchParams(window.location.search);

        if (oldSearchParams.toString() != newSearchParams.toString())
            setUrlParam("pagina", 1);
        else {
            setUrlParam("pagina", page);
        }
    }

    function loadingDataTable(loading) {
        let content = document.getElementsByClassName('ibox-content');
        if (content.length > 0) {
            if (loading) {
                content[0].classList.add('sk-loading');
            }
            else {
                content[0].classList.remove('sk-loading');
            }
        }
    }

    this.AoCarregar = async () => {
        loadingDataTable(true);

        let select = document.getElementById('itemsCount');
        let statusPagination = document.getElementById('statusPagination');
        let params = new URLSearchParams(new URL(window.location).search);

        let Placa = document.getElementById("consultaPlaca");
        Placa.value = params.get("Placa");
        let Marca = document.getElementById("consultaMarca");
        Marca.value = params.get("Marca");
        let Modelo = document.getElementById("consultaModelo");
        Modelo.value = params.get("Modelo");
        let Opcional = document.getElementById("consultaOpcional");
        Opcional.value = params.get("Opcional");
        let AnoMin = document.getElementById("consultaAnoMin");
        AnoMin.value = params.get("AnoMin");
        let AnoMax = document.getElementById("consultaAnoMax");
        AnoMax.value = params.get("AnoMax");
        let Preco = document.getElementById("consultaPreco");
        Preco.value = params.get("Preco");
        let Fotos = document.getElementById("consultaFoto");
        Fotos.value = params.get("Fotos");
        let Cor = document.getElementById("consultaCor");
        Cor.value = params.get("Cor");


        if (params.get("pagina") && params.get("quantidadePorPagina")) {
            select.value = params.get("quantidadePorPagina");
            setupRequest(params.get("pagina"), params.get("quantidadePorPagina"));
        } else {
            setupRequest(1, select.value); //adicionar parâmetros na url
            params = new URLSearchParams(new URL(window.location).search);
        }

        dataTable = new DataTable('table', false, parseInt(params.get("pagina")));

        const configs = [
            {
                "data": "Id",
                "sortEnabled": true,
                "header": "",
                "classBody": "table-protocolo__column-first",
                "render": (data) => {
                    return `
                    <div class="coluna-exclusao">
                        <a onclick="window.ExcluirVeiculo(${data.Id})">
                            <i class="fas fa-trash-alt icone-exclusao" style="color:red;"></i>
                        </a>
                    </div>`;
                }
            },
            {
                "sortEnabled": true,
                "header": "",
                "render": (data) => {
                    return `
                    <div class="coluna-imagem-veiculo">
                        <img class="imagem-veiculo-listagem" src="/${data.Fotos[0]}" />
                    </div>
                    `;
                }
            },
            {
                "sortEnabled": true,
                "header": "",
                "render": (data) => {
                    let placaFormatada = data.Placa;
                    if (placaFormatada.length > 3) {
                        placaFormatada = placaFormatada.slice(0, 3) + "-" + placaFormatada.slice(3);
                    }
                    let qtdFotosFormatado = data.Fotos.length;
                    if (qtdFotosFormatado < 10)
                        qtdFotosFormatado = '0' + qtdFotosFormatado.toString();
                    return `
                    <div class="coluna-dados-veiculo">
                        <div class="campo-marcaModeloAno">
                            <b id="campo-marcaModeloAno">${data.Marca.toUpperCase()} ${data.Modelo.toUpperCase()} | ${data.Ano}</b>
                        </div>
                        <div style="display: flex; margin: 30px 0px 6px 10px;">
                            <div class="campos-placaKmCor" style="width: 50%;">
                                <span id="campo-placa">Placa - <span class="green">${placaFormatada.toUpperCase()}</span></span>
                                <span id="campo-km">Km - <span class="green">${data.Km}</span></span>
                                <span id="campo-cor">Cor - <span class="green">${data.Cor}</span></span>
                            </div>
                            <div class="campos-editarFotosOpcionais" style="width: 50%;">
                                <div class="container-botaoEdicaoVeiculo">
                                    <i class="far fa-edit botaoEdicaoVeiculo"></i>
                                </div>    
                                <div style="display: flex; flex-direction: column; align-items: center; margin: 0px 15px 0px 5px;">
                                    <i class="fas fa-camera iconeQtdFotos"></i>
                                    <span class="green">${qtdFotosFormatado}</span>
                                </div>
                                <div style="display: flex; flex-direction: column; align-items: center;">
                                    <img id="iconeOpcionais" src="/Images/opcionais.png" />
                                    <span class="green">Opcionais</span>
                                </div>
                            </div>
                        </div>
                        <div class="container-campo-preco">
                            <span class="campo-preco">R$ ${data.Preco}</span>
                        </div>
                    </div>
                    `;
                }
            },
            {
                "data": "Ano",
                "sortEnabled": true,
                "header": "",
                "render": (data) => {
                    return `
                    <div class="coluna-pacotes">
                        <div class="coluna-pacotes-icarros">
                            <div style="margin-bottom: 5px;">
                                <label class="pacote-titulo">Diamante Feirão</label>
                                <div>
                                    <input type="checkbox"/>
                                    <span class="red">010</span><span> - </span><span class="green">008</span>
                                </div>
                            </div>
                            <div style="margin-bottom: 5px;">
                                <label class="pacote-titulo">Diamante</label>
                                <div>
                                    <input type="checkbox"/>
                                    <span class="red">030</span><span> - </span><span class="green">025</span>
                                </div>
                            </div>
                            <div>
                                <label class="pacote-titulo">Platinum</label>
                                <div style="margin-top: 3px;">
                                    <input type="checkbox" />
                                    <span class="red">040</span><span> - </span><span class="green">010</span>
                                </div>
                            </div>
                        </div>
                        <div class="coluna-pacotes-webmotors">
                            <div>
                                <label class="pacote-titulo">Básico</label>
                                <div>
                                    <input type="checkbox" />
                                    <span class="red">030</span><span> - </span><span class="green">025</span>
                                </div>
                            </div>
                        </div>
                    </div>
                    `;
                }
            }
        ];

        dataTable.setColumns(configs, false);

        let data = await getVeiculo(params);

        document.getElementById("btnFilterConfirmation").addEventListener('click', async () => {
            await changePage(statusPagination, select);
        });

        document.getElementById("btnCadastrarVeiculo").addEventListener('click', () => {
            cadastrarVeiculo();
        });

        document.addEventListener('previousPageEvent', async () => {
            await changePage(statusPagination, select);
        }, false);

        document.addEventListener('nextPageEvent', async () => {
            await changePage(statusPagination, select);
        }, false);

        select.addEventListener("change", async () => {
            await changePage(statusPagination, select);
        });

        dataTableFill(statusPagination, select, data, params.get('pagina'));
        dataTable.setButtonsPaginated(false, data?.Total);

        loadingDataTable(false);
    }


    this.ExportarItem = async (id) => {
        loadingDataTable(true);

        const ids = [id];

        axios({
            responseType: 'arraybuffer',
            method: 'post',
            url: '/API/Veiculo/ExportarEstoque',
            data: ids
        }).then((response) => {
            const contentDisposition = response.headers['content-disposition'];
            const filename = contentDisposition.match(/filename=(?<filename>[^,;]+);/)[0]
                .replace(';', '')
                .split('=')[1];

            loadingDataTable(false);

            if (response.data) {
                swal("Exportação realizada!", "Exportação realizada com sucesso.", "success");
            }
            else {
                swal("Falha ao exportar Veiculos", response.data.Mensagem, "error");
            }

            const url = window.URL.createObjectURL(new Blob([response.data]));
            const link = document.createElement('a');
            link.href = url;
            link.setAttribute('download', filename);
            document.body.appendChild(link);
            link.click();
            loadingDataTable(false);
        }).catch((error) => {
            swal("Falha ao exportar Veiculos", error, "error");
            loadingDataTable(false);
        });
    };
    
};

var oPagina = new Pagina();
function ready() {

    oPagina.AoCarregar();
}

function completed() {
    document.removeEventListener("DOMContentLoaded", completed);
    window.removeEventListener("load", completed);
    ready();
}

if (document.readyState === "complete" ||
    (document.readyState !== "loading" && !document.documentElement.doScroll)) {
    ready(); // está pronto!
} else { // ainda não está pronto...
    document.addEventListener("DOMContentLoaded", completed);
    window.addEventListener("load", completed);
}

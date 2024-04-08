const apiUrl = "https://localhost:7226/api/TaskToDo";
const searchBar = document.getElementById("search-bar");
let allTasks;
let searchTasks;
let orderBy = 'completed-descending';
let lockModalScreen = false;

//////////////////////////////////////
// Classe taskToDo
class TaskToDo {
    id = 0;
    name = "";
    taskState = 0;
    constructor(params){
        if(params)
            Object.assign(this, params)
    }

    createTemplate(){
        const templateUnfinished = `
        <div class="card d-flex p-2 flex-row gap-2 flex-wrap align-items-center shadow-sm task-unfinished"">
            <button class="point" onclick="toogleCompleteTaskFn(${this.id})"></button>                            
            <p class="card-content flex-grow-1 px-2 overflow-hidden">
                ${this.name}
            </p>
            <div class="btn-group d-flex">
                <button onclick="deleteTaskFn(${this.id})" class="btn-delete-task btn btn-outline-danger px-3 fw-500">
                    Excluir
                </button>
                <button onclick="editTaskFn(${this.id})" class="btn-edit-task btn btn-outline-warning px-3 fw-500">
                    Editar
                </button>
                <button onclick="toogleCompleteTaskFn(${this.id})" class="btn-complete-task btn btn-outline-primary px-3 fw-500">
                    Concluir
                </button>
            </div>
        </div>`;
        const templateFinished = `
        <div class="card d-flex p-2 flex-row gap-2 flex-wrap align-items-center shadow-sm task-finished">
            <button class="point" onclick="toogleCompleteTaskFn(${this.id})">
                <i class="fas fa-check"></i>
            </button>           
            <p class="card-content flex-grow-1 px-2 overflow-hidden">
                ${this.name}
            </p>
            <div class="btn-group d-flex">
                <button onclick="deleteTaskFn(${this.id})" class="btn-delete-task btn btn-outline-danger px-3 fw-500">
                    Excluir
                </button>
            </div>
        </div>`;

        return this.taskState === 0? templateUnfinished : templateFinished;
    }
}

//////////////////////////////////////
// Funções
function createTaskFn()
{
    if(lockModalScreen)
        return;

    const modalProps = {
        id: 'create-task',
        title: 'Criar Tarefa',
        description: 'Escolha um nome para sua tarefa',
        iconCode: 'fa-plus' // Ícone do FontAwesome
    };

    const createInputElement = inputElementFactory(
        'Digite o nome da tarefa',
        'text', true,
        'Por favor, preencha o nome da tarefa.'
    );

    const modal = new ModalInputElement(modalProps, 'Cancelar', 'Confirmar', createInputElement);
    modal.open();

    modal.close((event) => {
        refreshView();
    });

    modal.handlerPrimaryAction((event) => {
        const taskName = event.input.value;
        const body = {
            name: taskName
            }
            
        $.ajax({
            url: apiUrl,
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(body),
            success: function (response) {
                getTasks();
            },
            error: function (xhr, status, error) {
                console.error('Erro na solicitação:', error);
            }
        });
    });
}

function deleteTaskFn(taskId) 
{
    if(lockModalScreen)
        return;

    const modalProps = {
        id: 'delete-task',
        title: 'Deseja excluir a tarefa?',
        description: 'Clique em confirmar para excluir. Lembre-se: esta ação é irreversível.',
        iconCode: 'fa-trash' // Ícone do FontAwesome
    };

    const modal = new ModalAction(modalProps, 'Fechar', 'Confirmar');
    modal.open();
    
    modal.close((event) => {
        refreshView();
    });

    modal.handlerPrimaryAction((event) => {
        const body = {
            id: taskId,
        }

        $.ajax({
            url: apiUrl+"?id="+taskId,
            method: 'DELETE',
            contentType: 'application/json',
            // data: JSON.stringify(body),
            success: function (response) {
                getTasks();
            },
            error: function (xhr, status, error) {
                console.error('Erro na solicitação:', error);
            }
        });
    });
}

function editTaskFn(taskId) 
{
    if(lockModalScreen)
        return;
        
    const modalProps = {
        id: 'edit-task',
        title: 'Editar Tarefa',
        description: 'Edite sua tarefa',
        iconCode: 'fa-pen' // Ícone do FontAwesome
    };

    const editInputElement = inputElementFactory(
        'Editar nome da tarefa',
        'text', true,
        'Por favor, preencha o nome da tarefa.'
    );

    const modal = new ModalInputElement(modalProps, 'Cancelar', 'Confirmar', editInputElement);

    modal.open();
    
    modal.close((event) => {
        refreshView();
    });

    modal.handlerPrimaryAction((event) => {
        const task = getTaskById(taskId);
        const taskName = event.input.value;
        const body = {
            id: taskId,
            name: taskName,
            taskState: task.taskState
        }
        
        $.ajax({
            url: apiUrl,
            method: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify(body),
            success: function (response) {
                getTasks();
            },
            error: function (xhr, status, error) {
                console.error('Erro na solicitação:', error);
            }
        });
    });

}

function toogleCompleteTaskFn(taskId) {
    const task = getTaskById(taskId);
    const body = {
        id: taskId,
        name: task.name,
        taskState: task.taskState === 0? 1 : 0
    }

    $.ajax({
        url: apiUrl,
        method: 'PUT',
        contentType: 'application/json',
        data: JSON.stringify(body),
        success: function (response) {
            getTasks();
        },
        error: function (xhr, status, error) {
            console.error('Erro na solicitação:', error);
        }
    });
}

function getTaskById(taskId){
    const task = allTasks.find(task => task.id === taskId);

    return task;
}

function getTasks() {
    $.ajax({
        url: apiUrl,
        method: 'GET',
        contentType: 'application/json',
        success: function (response) {
            allTasks = response.data;
            refreshView();
        },
        error: function (xhr, status, error) {
            console.error('Erro na solicitação:', error);
        }
    });
}

function refreshView(taskList){
    clearModalTemplates();
    const cardsWrapper = document.getElementById("cards-wrapper");
    let wrapperInnerHtml = '';
    
    if(!taskList)
        taskList = allTasks;

    taskList
    .map(taskToDo => new TaskToDo(taskToDo))
    .sort((a, b) => {

        if (orderBy == 'completed' && a.taskState !== b.taskState) {
            return b.taskState - a.taskState;
        } 

        if (orderBy == 'completed-descending' && a.taskState !== b.taskState) {
            return a.taskState - b.taskState;
        } 

        if (orderBy == 'name') {
            return a.name.localeCompare(b.name);
        } 

        if (orderBy == 'name-descending') {
            return b.name.localeCompare(a.name);
        } 
        
        return b.id - a.id;
    })
    .forEach(model => {
        wrapperInnerHtml += model.createTemplate();
    });

    cardsWrapper.innerHTML = wrapperInnerHtml;
}

function clearModalTemplates(){
    lockModalScreen = true;
    setTimeout(() => {
        let modalTemplates = document.querySelectorAll(".modal-template");
        
        modalTemplates.forEach(template => {
            template.parentElement.remove();
        });

        lockModalScreen = false;
    }, 1000);
}

function changeOrderBy(sortType = 'completed'){
    const switchedOrderby = !orderBy.includes(sortType);

    orderBy = orderBy == sortType+'-descending'? sortType : sortType+'-descending';
    if(switchedOrderby)
        changeOrderByIcon();
    refreshView();
}

function changeOrderByIcon(){
    const btns = document.querySelectorAll(".btn-order-by");

    btns.forEach(btn => {
        if(btn.classList.contains('active')){
            btn.classList.remove('active');
            return;
        }
    
        if(!btn.classList.contains('active')){
            btn.classList.add('active');
            return;
        }
    })
}

function onChangeSearchBar(event){
    const searchValue = event.target.value;

    const searchList = allTasks.filter(task => task.name.toLowerCase().includes(searchValue.toLowerCase()));
    refreshView(searchList);
}

searchBar.addEventListener('change', function(ev) {
    onChangeSearchBar(ev);
});

getTasks();
//https://getbootstrap.com/docs/5.0/components/pagination/
//https://stackoverflow.com/questions/52919972/javascript-populate-table
//https://getbootstrap.com/docs/5.1/content/tables/
//https://cb1ijc.axshare.com/#id=cy9yfw&p=consultar_protocolos&g=1

class DataTable {
    rowsCount = 0;
    #currentPage;
    #delimiter;

    constructor(tableId, setDefaultButtonsPaginated, currentPage) {
        this.tableId = tableId;
        this.#currentPage = currentPage;

        const tableElement = document.getElementById(tableId);

        if (tableElement === null) {
            throw new InvalidArgumentException('Tag with id invalid.');
        }

        if (tableElement.nodeName !== 'TABLE') {
            throw new InvalidArgumentException(`Tag with id ${tableId} does not a TABLE.`);
        }

        const tbodyElements = tableElement.getElementsByTagName('tbody');
        const tbodyElement = (tbodyElements.length > 0) ? tbodyElements[0] : tableElement.createTBody();
        this.rowsCount = tbodyElement.length;

        if (setDefaultButtonsPaginated) {
            this.#setDefaultButtonsPaginated();
        }
    }

    getCurrentPage() {
        return this.#currentPage;
    }

    setCurrentPage(value) {
        this.#currentPage = value;
    }

    setRows(rowsCount, table) {
        if (rowsCount == this.rowsCount)
            return;

        if (rowsCount > this.rowsCount) {
            let count = rowsCount - this.rowsCount;
            this.#addRows(count, table);
        }

        if (rowsCount < this.rowsCount) {
            let count = this.rowsCount - rowsCount;
            this.#removeRows(count, table);
        }

        this.rowsCount = rowsCount;
    }

    #addRows(count, table) {
        for (let i = 0; i < count; i++) {
            table.insertRow();
        }
    }

    #removeRows(count, table) {
        for (let i = 0; i < count; i++) {
            table.deleteRow(table.rows.length - 1);
        }
    }

    setCells(cellCount, row) {
        if (cellCount == row.cells.length)
            return;

        if (cellCount > row.cells.length) {
            let count = cellCount - row.cells.length;
            this.#addCells(count, row);
        }

        if (cellCount < row.cells.length) {
            let count = row.cells.length - cellCount;
            this.#removeCells(count, row);
        }

        return cellCount;
    }

    #addCells(count, row) {
        for (let i = 0; i < count; i++) {
            row.insertCell(0);
        }
    }

    #removeCells(count, row) {
        for (let i = 0; i < count; i++) {
            row.deleteCell(row.cells.length - 1);
        }
    }

    #setDefaultButtonsPaginated() {
        let table = document.getElementById(this.tableId);
        table.outerHTML += '<nav id="navPagination" aria-label="Pagination"><ul class="pagination"><li class="page-item"><a class="page-link" id="previous" href="#">Previous</a></li><li class="page-item"><a class="page-link" name="numberPagination" href="#">1</a></li><li class="page-item"><a class="page-link" name="numberPagination" href="#">2</a></li><li class="page-item"><a class="page-link" name="numberPagination" href="#">3</a></li><li class="page-item"><a class="page-link" id="next" href="#">Next</a></li></ul></nav>';
        this.setButtonsPaginated(true);
    }

    setButtonsPaginated(keepOldNavPagination, totalCount) {
        if (!keepOldNavPagination) {
            let navPagination = document.getElementById('navPagination');
            if (!!navPagination) {
                navPagination.remove();
            }
        }

        let previousElement = document.getElementById('previous');
        let nextElement = document.getElementById('next');

        let previousPageEvent = new CustomEvent("previousPageEvent", { detail: { sender: this, page: this.#currentPage } });
        let nextPageEvent = new CustomEvent("nextPageEvent", { detail: { sender: this, page: this.#currentPage } });

        if (this.#currentPage === 1) {
            previousElement.setAttribute("disabled", "disabled");
        }


        if (!!previousElement) {
            previousElement.onclick = () => {

                if (this.#currentPage > 1) {
                    this.#currentPage--;
                }

                document.dispatchEvent(previousPageEvent);
            };
        }
        else {
            console.error("Element with id 'previous' does not exist.");
        }

        if (this.#currentPage >= (totalCount / this.rowsCount)) {
            nextElement.setAttribute("disabled", "disabled");
        }

        if (!!nextElement) {
            nextElement.onclick = () => {

                if (!this.nextElementEvent) {
                    if (this.#currentPage < (totalCount / this.rowsCount)) {
                        this.#currentPage++;
                    }

                    document.dispatchEvent(nextPageEvent);
                }
            };
        }
        else {
            console.error("Element with id 'next' does not exist.");
        }

        let changePageEvent = new CustomEvent("changePageEvent", { detail: { sender: this, page: this.#currentPage } });

        let numberElements = document.getElementsByName('numberPagination');

        numberElements.forEach(item => item.onclick = () => {
            let numberStr = item.innerText.trim();
            this.#currentPage = parseInt(numberStr);

            if (!this.nextElementEvent) {
                document.dispatchEvent(changePageEvent);
            }
        });
    }

    getDataFromCheckedCheckboxs() {
        let checkedData = [];
        let checkboxes = Array.from(document.getElementsByName('datatable-checkbox'));

        for (let i = 0; i < checkboxes.length; i++) {
            if (checkboxes[i].checked) {
                checkedData.push(this.data[i]);
            }
        }

        return checkedData;
    }

    #changeInteractionButtonsPaginated(totalCount, delimiter, previousElement, nextElement) {
        if (!!previousElement) {
            if (parseInt(this.#currentPage) === 1) {
                previousElement.setAttribute("disabled", "disabled");
            }
            else {
                previousElement.removeAttribute("disabled");
            }
        }

        if (!!nextElement) {
            if (delimiter >= totalCount) {
                nextElement.setAttribute("disabled", "disabled");
            }
            else {
                nextElement.removeAttribute("disabled");
            }
        }
    }

    setColumns(configs, enableChecklists) {

        if (!Array.isArray(configs)) {
            console.error('Only array are allowed.');
            return;
        }

        let headConfigsMap = configs.map(x => {
            return {
                data: x.data,
                header: x.header,
                classHeader: x.classHeader,
                sortEnabled: x.sortEnabled
            }
        });

        this.#setHeader(headConfigsMap, enableChecklists);
        this.enableChecklists = enableChecklists;
        this.bodyConfigsMap = configs.map(x => {
            return {
                data: x.data,
                classBody: x.classBody,
                render: x.render
            }
        });
    }

    #sortTableAscending(index) {
    var table, rows, switching, i, x, y, shouldSwitch;
    table = document.getElementById(this.tableId);
    switching = true;
    /* Make a loop that will continue until
    no switching has been done: */
    while (switching) {
        // Start by saying: no switching is done:
        switching = false;
        rows = table.rows;
        /* Loop through all table rows (except the
        first, which contains table headers): */
        for (i = 1; i < (rows.length - 1); i++) {
            // Start by saying there should be no switching:
            shouldSwitch = false;
            /* Get the two elements you want to compare,
            one from current row and one from the next: */
            x = rows[i].getElementsByTagName("TD")[index];
            y = rows[i + 1].getElementsByTagName("TD")[index];
            // Check if the two rows should switch place:
            if (x.innerText.toLowerCase() > y.innerText.toLowerCase()) {
                // If so, mark as a switch and break the loop:
                shouldSwitch = true;
                break;
            }
        }
        if (shouldSwitch) {
            /* If a switch has been marked, make the switch
            and mark that a switch has been done: */
            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;
        }
    }
}

    #sortTableDescending(index) {
    var table, rows, switching, i, x, y, shouldSwitch;
    table = document.getElementById(this.tableId);
    switching = true;
    /* Make a loop that will continue until
    no switching has been done: */
    while (switching) {
        // Start by saying: no switching is done:
        switching = false;
        rows = table.rows;
        /* Loop through all table rows (except the
        first, which contains table headers): */
        for (i = 1; i < (rows.length - 1); i++) {
            // Start by saying there should be no switching:
            shouldSwitch = false;
            /* Get the two elements you want to compare,
            one from current row and one from the next: */
            x = rows[i].getElementsByTagName("TD")[index];
            y = rows[i + 1].getElementsByTagName("TD")[index];
            // Check if the two rows should switch place:
            if (x.innerText.toLowerCase() < y.innerText.toLowerCase()) {
                // If so, mark as a switch and break the loop:
                shouldSwitch = true;
                break;
            }
        }
        if (shouldSwitch) {
            /* If a switch has been marked, make the switch
            and mark that a switch has been done: */
            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;
        }
    }
}

    #setHeader(configsHeader, enableChecklists) {
        const table = document.getElementById(this.tableId);

        let header = table.getElementsByTagName('thead')[0];

        this.setRows(1, header);

        let row;
        if (!header) {
            header = table.createTHead();
            row = header.insertRow(0);
        }
        else {
            let rows = header.rows;
            row = rows[0];
        }

        this.setCells((enableChecklists) ? configsHeader.length + 1 : configsHeader.length, row);
        
        let ascendingDescendingColumns = [];

        if (enableChecklists) {
            let cell = table.getElementsByTagName('thead')[0].rows[0].cells[0];
            cell.classList.add("text-center");

            let mainCheckbox = document.createElement("input");
            mainCheckbox.setAttribute("class", "form-check-input");
            mainCheckbox.setAttribute("type", "checkbox");

            mainCheckbox.addEventListener("change", () => {
                let checkboxes = document.getElementsByName('datatable-checkbox'); //resgatar todos os checkboxs da primeira coluna
                for (let i = 0; i < checkboxes.length; i++) {
                    checkboxes[i].checked = mainCheckbox.checked;
                }
            });

            cell.innerHTML = "";
            cell.append(mainCheckbox);
        }

        configsHeader.forEach((configheader, i) => {
            if (enableChecklists) 
                i++;

            let cell = table.getElementsByTagName('thead')[0].rows[0].cells[i];

            if (configheader.classHeader != undefined)
                cell.className = configheader.classHeader;

            let span = document.createElement("span");
            span.innerHTML = configheader.header;

            if (configheader.sortEnabled) {
                ascendingDescendingColumns.push(null);

                span.setAttribute("style", "cursor: pointer;");

                let icon = document.createElement("i");
                icon.className = "bi bi-arrow-down-up ms-2";
                span.appendChild(icon);
                span.addEventListener("click", () => {

                    if (ascendingDescendingColumns[i] === false || ascendingDescendingColumns[i] === null) {
                        this.#sortTableAscending(i);
                        ascendingDescendingColumns[i] = true;
                        let compareColumns = Array.from(ascendingDescendingColumns);

                        const index = compareColumns.indexOf(ascendingDescendingColumns[i]);
                        if (index > -1) {
                            compareColumns.splice(index, 1); // 2nd parameter means remove one item only
                        }

                        if (compareColumns.some((x) => x == true || x == false)) {
                            ascendingDescendingColumns.forEach(item => { //reset all bools
                                item = false;
                            });
                        }
                    }
                    else {
                        this.#sortTableDescending(i);
                        ascendingDescendingColumns[i] = false;
                    }
                });
            }

            cell.innerHTML = "";
            cell.append(span);
        });
    }

    #render(data) {
        if (!Array.isArray(data)) {
            console.error('Only array are allowed.');
            return;
        }

        let tbody = document.getElementById(this.tableId).getElementsByTagName('tbody')[0];
        this.setRows(0, tbody);
        this.setRows(data.length, tbody);
        let rows = tbody.rows;

        data.forEach((item, i) => { //rows

            this.setCells((this.enableChecklists) ? this.bodyConfigsMap.length + 1 : this.bodyConfigsMap.length, rows[i]);

            var result = Object.keys(item).map((key) => [key, item[key]]);

            if (this.enableChecklists) {
                let cell = rows[i].cells[0];
                cell.className = "text-center";

                let checkbox = document.createElement("input");
                checkbox.className = "form-check-input";
                checkbox.setAttribute("style", "text-align: center !important;");
                checkbox.setAttribute("type", "checkbox");
                checkbox.setAttribute("name", "datatable-checkbox");

                cell.innerHTML = "";
                cell.append(checkbox);

            }

            for (let j = 0; j < this.bodyConfigsMap.length; j++) { //cells
                let keyValuePair = result.find(y => y[0] == this.bodyConfigsMap[j].data);
                let a = (this.enableChecklists) ? j + 1 : j;

                let cell = rows[i].cells[a];

                let render = this.bodyConfigsMap[j].render;
                if (!!render) {
                    cell.innerHTML = (!!result[j]) ? render(item) : render();
                }
                else {
                    cell.innerHTML = (keyValuePair === undefined) ? null : keyValuePair[1];
                }

                let classBody = this.bodyConfigsMap[j].classBody;
                if (!!classBody) {
                    cell.className = classBody;
                }
            }

        });
    }

    fill(totalCount, delimiter, data, previousId, nextId) {
        this.data = data;
        this.#render(data);
        this.#delimiter = delimiter;

        const previousElement = document.getElementById(previousId);
        const nextElement = document.getElementById(nextId);

        this.#changeInteractionButtonsPaginated(totalCount, delimiter, previousElement, nextElement);
    }

}

function InvalidArgumentException(message) {
    this.message = message;
    this.name = "InvalidArgumentException";
}
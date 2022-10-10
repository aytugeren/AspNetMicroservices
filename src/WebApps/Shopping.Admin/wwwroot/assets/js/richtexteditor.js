let optionsButtons = document.querySelectorAll(".option-button");
let advancedOptionButton = document.querySelectorAll(".adv-option-button");
let fontName = document.getElementById("fontName");
let fontSizeRef = document.getElementById("fontSize");
let writingArea = document.getElementById("text-input");
let writingArea2 = document.getElementById("text-input2");
let buttonTitle = document.getElementById("buttonTitle");
let pictureArea = document.getElementById("pictureArea");
let linkButton = document.getElementById("createLink");
let editButton = document.querySelectorAll("#editButton");
let alignButtons = document.querySelectorAll(".align");
let spacingButtons = document.querySelectorAll(".spacing");
let formatButtons = document.querySelectorAll(".format");
let scriptButtons = document.querySelectorAll(".script");
let writingAreaText = "";
let writingAreaText2 = ""
let buttonTitleText = "";
let img = ""

//List of fontlist
let fontList = [
    "Arial",
    "Verdana",
    "Times New Roman",
    "Garamond",
    "Georgia",
    "Courier New",
    "cursive",
];
//Initial Settings
const initializer = () => {
    //function calls for highlighting buttons
    //No highlights for link, unlink,lists, undo,redo since they are one time operations
    highlighter(alignButtons, true);
    highlighter(spacingButtons, true);
    highlighter(formatButtons, false);
    highlighter(scriptButtons, true);
    //create options for font names
    fontList.map((value) => {
        let option = document.createElement("option");
        option.value = value;
        option.innerHTML = value;
        fontName.appendChild(option);
    });
    //fontSize allows only till 7
    for (let i = 1; i <= 7; i++) {
        let option = document.createElement("option");
        option.value = i;
        option.innerHTML = i;
        fontSizeRef.appendChild(option);
    }
    //default size
    fontSizeRef.value = 3;
    writingArea.innerHTML = writingAreaText;
    writingArea2.innerHTML = writingAreaText2;
    buttonTitle.value = buttonTitleText
    pictureArea.src = 'https://res.cloudinary.com/takgelsin/image/upload/'+img;

};
//main logic
const modifyText = (command, defaultUi, value) => {
    //execCommand executes command on selected text
    document.execCommand(command, defaultUi, value);
};
//For basic operations which don't need value parameter
optionsButtons.forEach((button) => {
    button.addEventListener("click", () => {
        modifyText(button.id, false, null);
    });
});
//options that require value parameter (e.g colors, fonts)
advancedOptionButton.forEach((button) => {
    button.addEventListener("change", () => {
        modifyText(button.id, false, button.value);
    });
});

//link
linkButton.addEventListener("click", () => {
    let userLink = prompt("Enter a URL");
    //if link has http then pass directly else add https
    if (/http/i.test(userLink)) {
        modifyText(linkButton.id, false, userLink);
    } else {
        userLink = "http://" + userLink;
        modifyText(linkButton.id, false, userLink);
    }
});

//Edit button clicked button
async function editButtonFunction(id) {
    var url = "http://localhost:8010/Catalog/AdminGetContentCatalogById/" + id
    await fetch(url, {
        method: 'GET',
        cache: 'no-cache'
    }).then((res) => res.json()).then((response) => {
        writingAreaText = response.contentHtml;
        writingAreaText2 = response.contentHtml2;
        buttonTitleText = response.buttonHtml;
        img = response.contentImage
        initializer();
    })
}



//Highlight clicked button
const highlighter = (className, needsRemoval) => {
    className.forEach((button) => {
        button.addEventListener("click", () => {
            //needsRemoval = true means only one button should be highlight and other would be normal
            if (needsRemoval) {
                let alreadyActive = false;
                //If currently clicked button is already active
                if (button.classList.contains("active")) {
                    alreadyActive = true;
                }
                //Remove highlight from other buttons
                highlighterRemover(className);
                if (!alreadyActive) {
                    //highlight clicked button
                    button.classList.add("active");
                }
            } else {
                //if other buttons can be highlighted
                button.classList.toggle("active");
            }
        });
    });
};
const highlighterRemover = (className) => {
    className.forEach((button) => {
        button.classList.remove("active");
    });
};

window.onload = initializer();
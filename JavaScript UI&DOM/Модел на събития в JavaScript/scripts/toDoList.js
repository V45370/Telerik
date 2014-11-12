window.onload = function (){
	var add = document.getElementById("addButton"),
		remove = document.getElementById("removeButton"),
		show = document.getElementById("showButton"),
		hide = document.getElementById("hideButton"),
		toDoList = document.getElementById("list"),
		listDiv = document.getElementById("theList"),
		newItem = document.getElementById("newItem");

		add.addEventListener("click", function() {
			var option = document.createElement("option");
			option.value = newItem.value;
			option.innerText = newItem.value;
			toDoList.appendChild(option);
			toDoList.size = toDoList.size + 1;	    
		}, false); 

		remove.addEventListener("click", function() {
			toDoList.remove(toDoList.selectedIndex);    
		}, false); 

		show.addEventListener("click", function() {
			listDiv.style.visibility = "visible";    
		}, false); 

		hide.addEventListener("click", function() {
		    listDiv.style.visibility = "hidden";
		}, false); 

}

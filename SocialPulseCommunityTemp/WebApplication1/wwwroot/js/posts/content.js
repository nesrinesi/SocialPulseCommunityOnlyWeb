// Tab functionality
function openTab(event, tabName) {
  // Hide all content
  document.querySelectorAll(".content").forEach((content) => {
    content.classList.remove("active");
  });

  // Deactivate all tabs
  document.querySelectorAll(".tab").forEach((tab) => {
    tab.classList.remove("active");
  });

  // Show the selected content
  document.getElementById(tabName).classList.add("active");

  // Activate the clicked tab
  event.currentTarget.classList.add("active");
}

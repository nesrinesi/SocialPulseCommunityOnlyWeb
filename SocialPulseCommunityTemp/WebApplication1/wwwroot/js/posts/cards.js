document.addEventListener("DOMContentLoaded", function () {
  const cardData = [
    {
      img: "https://cdn-front.freepik.com/images/ai/image-generator/how-to/image-generator-freepik-4.webp?w=1080&amp;h=1920&amp;q=90",
      title: "Strawberry Treats",
      desc: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maiores beatae laboriosam dolores, accusamus quod repudiandae illo, ea dolorem nemo excepturi nam minus tempore, ipsam veritatis ipsa voluptates provident! Voluptate, rem.",
      date: "Dec 17",
      author: "theketokrush",
      link: "#",
    },
    {
      img: "https://cravinghomecooked.com/wp-content/uploads/2019/12/chocolate-cake-1-25-750x938.jpg.webp",
      title: "Chocolate Cake",
      desc: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maiores beatae laboriosam dolores, accusamus quod repudiandae illo, ea dolorem nemo excepturi nam minus tempore, ipsam veritatis ipsa voluptates provident! Voluptate, rem.",
      date: "Dec 18",
      author: "theketokrush",
      link: "#",
    },
    {
      img: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTwYnY98LTkjsPGxaKokvgs-3OdH8voq8vCVV9kIopnLthLvMkincvR2xfw8O5TOtIzzD8&amp;usqp=CAU",
      title: "Berry Cheesecake",
      desc: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maiores beatae laboriosam dolores, accusamus quod repudiandae illo, ea dolorem nemo excepturi nam minus tempore, ipsam veritatis ipsa voluptates provident! Voluptate, rem.",
      date: "Dec 19",
      author: "theketokrush",
      link: "#",
    },
  ];

  const cardContainer = document.getElementById("cardContainer");
  const postModal = document.getElementById("cardModal"); // The modal
  const closeModal = document.querySelector(".close"); // Close button

  const modalImage = document.getElementById("modalImage");
  const modalTitle = document.getElementById("modalTitle");
  const modalDesc = document.getElementById("postDesc");
  const modalDate = document.getElementById("modalDate");
  const modalAuthor = document.getElementById("modalAuthor");
  const modalLink = document.getElementById("postLink");

  function generateCards(number) {
    cardContainer.innerHTML = "";

    for (let i = 0; i < number; i++) {
      const data = cardData[i % cardData.length];
      const card = document.createElement("div");
      card.classList.add("card");
      card.innerHTML = `
        <img src="${data.img}" alt="${data.title}">
        <div class="content">
          <h3>${data.title}</h3>
          <p>${data.desc}</p>
          <span>${data.date} - ${data.author}</span>
        </div>
      `;

      // Click event to open details
      card.addEventListener("click", function () {
        modalImage.src = data.img;
        modalTitle.textContent = data.title;
        modalDesc.textContent = data.desc;
        modalLink.href = data.link;
        modalLink.textContent = "View More";

        // Show the modal
        postModal.style.display = "flex";
      });

      cardContainer.appendChild(card);
    }
  }

  // Close modal when clicking on the close button
  closeModal.addEventListener("click", function () {
    postModal.style.display = "none";
  });

  // Close modal when clicking outside the modal content
  window.addEventListener("click", function (event) {
    if (event.target === postModal) {
      postModal.style.display = "none";
    }
  });

  // Generate cards
  generateCards(6);
});

let imageInput = document.getElementById("imageInput");

function editPost() {
  let postDesc = document.getElementById("postDesc");
  let postLink = document.getElementById("postLink");

  // Enable editing
  postDesc.contentEditable = true;
  postDesc.focus();
  postLink.contentEditable = true;
}

function uploadImage() {
  imageInput.click();
}

imageInput.addEventListener("change", function () {
  let imageContainer = document.getElementById("imageContainer");
  let file = imageInput.files[0];

  if (!file) return;

  let reader = new FileReader();
  reader.onload = function (e) {
    // Create a new image card
    let newCard = document.createElement("div");
    newCard.classList.add("imgedit");

    let img = document.createElement("img");
    img.src = e.target.result;

    let deleteBtn = document.createElement("button");
    deleteBtn.innerHTML = `<span class="typcn--delete"></span>`;
    deleteBtn.classList.add("deleteImgBtn");
    deleteBtn.onclick = function () {
      newCard.remove();
    };

    newCard.appendChild(img);
    newCard.appendChild(deleteBtn);

    // Insert new image at the beginning (before the add button)
    let addButton = document.querySelector(".addImageCard");
    imageContainer.insertBefore(newCard, addButton);

    // **Fix duplication issue**: Reset input after selection
    imageInput.value = "";
  };
  reader.readAsDataURL(file);
});

function deleteImage(btn) {
  btn.parentElement.remove();
}

function deletePost() {
  let postContainer = document.getElementById("postContainer");

  // Confirm before deleting
  let confirmDelete = confirm("Are you sure you want to delete this post?");
  if (confirmDelete) {
    postContainer.remove(); // Remove the entire post
  }
}

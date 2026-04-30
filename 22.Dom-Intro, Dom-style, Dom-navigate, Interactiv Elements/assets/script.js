const card = document.createElement("div");
card.style.backgroundColor = "rgb(227, 225, 225)";
document.body.appendChild(card);

card.style.position = "relative";
card.style.width = "320px";
card.style.border = "1px solid #ccc";
card.style.borderRadius = "15px";
card.style.fontFamily = "Arial";

const img = document.createElement("img");
img.src = "./assets/images/main.png";
img.style.width = "100%";
card.appendChild(img);

const content = document.createElement("div");
content.style.padding = "10px";
card.appendChild(content);

const title = document.createElement("p");
title.innerText = "DETACHED HOUSE * 5Y OLD";
content.appendChild(title);

const price = document.createElement("h2");
price.innerText = "$750,000";
content.appendChild(price);

const address = document.createElement("p");
address.innerText = "742 Evergreen Terrace";
content.appendChild(address);

const info = document.createElement("div");
info.style.borderBottom = "1px solid #b77f7f";
info.style.borderTop = "1px solid #b77f7f";
info.style.padding = "20px";
info.style.display = "flex";
info.style.justifyContent = "center";
info.style.gap = "15px";
info.style.margin = "20px 0";
content.appendChild(info);

const bedi = document.createElement("span");
bedi.innerHTML = "3 Bedrooms";
info.appendChild(bedi);

const bathi = document.createElement("span");
bathi.innerHTML = "2 Bathrooms";
info.appendChild(bathi);

const realtor = document.createElement("div");
realtor.style.marginTop = "10px";
realtor.style.paddingTop = "10px";
realtor.style.backgroundColor = "#f3f3f3ff"
realtor.style.borderTop = "1px solid #eee";
content.appendChild(realtor);

const realtortitle = document.createElement("div");
realtortitle.innerText = "REALTOR";
realtortitle.style.fontSize = "12px";
realtortitle.style.fontWeight = "bold";
realtortitle.style.marginBottom = "10px";
realtortitle.style.paddingLeft = "10px";
realtor.appendChild(realtortitle);

const realtorinfo = document.createElement("div");
realtorinfo.style.display = "flex";
realtorinfo.style.alignItems = "center";
realtorinfo.style.padding = "0 10px";
realtor.appendChild(realtorinfo);

const realtorimg = document.createElement("img");
realtorimg.src = "./assets/images/profile.png";
realtorimg.style.width = "40px";
realtorimg.style.height = "40px";
realtorimg.style.borderRadius = "40%";
realtorimg.style.marginRight = "10px";
realtorimg.style.marginLeft = "10px";
realtorimg.style.marginBottom = "10px";
realtorinfo.appendChild(realtorimg);

const details = document.createElement("div");
details.style.display = "flex";
details.style.gap = "5px";
details.style.marginBottom = "10px";
details.style.flexDirection = "column";
realtorinfo.appendChild(details);

const realtorname = document.createElement("span");
realtorname.innerText = "Tiffany Heffner";
realtorname.style.fontSize = "14px";
realtorname.style.fontWeight = "bold";
details.appendChild(realtorname);

const realtorphone = document.createElement("span");
realtorphone.innerHTML = "(555) 555-4321";
realtorphone.style.fontSize = "12px";
details.appendChild(realtorphone);



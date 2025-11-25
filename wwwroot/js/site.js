const toggleBtn = document.getElementById("themeToggle");

toggleBtn.addEventListener("click", () => {
    document.body.classList.toggle("light-mode");

    // ikon değişsin
    if (document.body.classList.contains("light-mode")) {
        toggleBtn.textContent = "☀️";
        localStorage.setItem("theme", "light");
    } else {
        toggleBtn.textContent = "🌙";
        localStorage.setItem("theme", "dark");
    }
});

// sayfa açıldığında tema hatırlansın
if (localStorage.getItem("theme") === "light") {
    document.body.classList.add("light-mode");
    toggleBtn.textContent = "☀️";
}

function setMachineState(isActive) {
    const ring = document.getElementById('powerRing');
    const statusText = document.getElementById('machineStatusText');
    
    if (isActive) {
        ring.classList.add('running');
        statusText.innerText = "ÇALIŞIYOR";
        statusText.style.color = "#10b981"; // Yeşil yazı
        statusText.style.textShadow = "0 0 20px rgba(16, 185, 129, 0.4)";
    } else {
        ring.classList.remove('running');
        statusText.innerText = "BEKLEMEDE";
        statusText.style.color = "#cbd5e1"; // Gri yazı
        statusText.style.textShadow = "none";
    }
}
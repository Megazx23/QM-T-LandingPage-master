function sendWhatsAppMessage() {
    var name = document.getElementById("nameInput").value;
    var email = document.getElementById("emailInput").value;
    var phone = document.getElementById("phoneInput").value;
    var service = document.getElementById("serviceSelect").value;
    var note = document.getElementById("noteTextarea").value;

    // Validar que no estén vacíos los campos requeridos
    if (!name || !email || !phone || !service || !note) {
        Swal.fire({
            title: "Error",
            text: "All fields are required!",
            icon: "error"
        });
        return;
    }

    // Construye el mensaje con la información del formulario
    var message = "Name: " + name + "\n";
    message += "Email: " + email + "\n";
    message += "Phone: " + phone + "\n";
    message += "Service: " + service + "\n";
    message += "Note: " + note;

    // Elimina espacios y caracteres no numéricos del número de teléfono
    phone = phone.replace(/\D/g, "");

    // Números de teléfono
    var whatsappNumbers = [
        "+5218992593580",
        "+5218991269929"
    ];

    // se supone que recorre la lista de numeros y les manda el msj
    whatsappNumbers.forEach(function (whatsappNumber) {
        var whatsappLink = "https://wa.me/" + whatsappNumber + "?text=" + encodeURIComponent(message);
        window.open(whatsappLink);
    });

    // alerta de SweetAlert de éxito
    Swal.fire({
        icon: 'success',
        title: 'Success!',
        text: 'Your message has been sent successfully.',
    });

    // Limpiar el formulario
    clearForm();
}

function clearForm() {
    document.getElementById("nameInput").value = "";
    document.getElementById("emailInput").value = "";
    document.getElementById("phoneInput").value = "";
    document.getElementById("serviceSelect").selectedIndex = 0;
    document.getElementById("noteTextarea").value = "";
}

< !DOCTYPE html >
    <html lang="es">
        <head>
            <meta charset="UTF-8">
                <meta name="viewport" content="width=device-width, initial-scale=1.0">
                    <title>CRUD Productos</title>
                    <style>
                        table {width: 100%; border-collapse: collapse; margin-top: 20px; }
                        th, td {border: 1px solid black; padding: 8px; text-align: left; }
                        th {background - color: #f2f2f2; }
                    </style>
                </head>
                <body>

                    <h2>Gestión de Productos</h2>

                    <form id="productoForm">
                        <label>Nombre del Producto:</label>
                        <input type="text" id="nombreProducto" required><br><br>

                            <label>Presentación:</label>
                            <input type="text" id="presentacion" required><br><br>

                                <label>Código de Barras:</label>
                                <input type="text" id="codigoBarras"><br><br>

                                    <button type="submit">Agregar Producto</button>
                                </form>

                                    <h3>Lista de Productos</h3>
                                    <table>
                                        <thead>
                                            <tr>
                                                <th>ID</th>
                                                <th>Nombre</th>
                                                <th>Presentación</th>
                                                <th>Código de Barras</th>
                                            </tr>
                                        </thead>
                                        <tbody id="tablaProductos"></tbody>
                                    </table>

                                    <script>
                                        class Producto {
                                            constructor(id, nombreProducto, presentacion, codigoBarras) {
                                            this.id = id;
                                        this.nombreProducto = nombreProducto;
                                        this.presentacion = presentacion;
                                        this.codigoBarras = codigoBarras;
            }
        }

                                        let productos = [];
                                        let idCounter = 1;

                                        function agregarProducto(event) {
                                            event.preventDefault();

                                        const nombre = document.getElementById("nombreProducto").value.trim();
                                        const presentacion = document.getElementById("presentacion").value.trim();
                                        const codigoBarras = document.getElementById("codigoBarras").value.trim();

                                        // Validaciones
                                        if (nombre.length < 3) {
                                            alert("El nombre debe tener al menos 3 caracteres.");
                                        return;
            }

                                        if (presentacion.length < 3) {
                                            alert("La presentación debe tener al menos 3 caracteres.");
                                        return;
            }

                                        if (codigoBarras && codigoBarras.length < 5) {
                                            alert("El código de barras debe tener al menos 5 caracteres.");
                                        return;
            }

                                        // Crear objeto producto y agregar a la lista
                                        const nuevoProducto = new Producto(idCounter++, nombre, presentacion, codigoBarras);
                                        productos.push(nuevoProducto);
                                        actualizarTabla();

                                        // Limpiar formulario
                                        document.getElementById("productoForm").reset();
        }

                                        function actualizarTabla() {
            const tabla = document.getElementById("tablaProductos");
                                        tabla.innerHTML = ""; // Limpiar tabla antes de actualizar

            productos.forEach(producto => {
                                            let fila = `<tr>
                                            <td>${producto.id}</td>
                                            <td>${producto.nombreProducto}</td>
                                            <td>${producto.presentacion}</td>
                                            <td>${producto.codigoBarras || 'N/A'}</td>
                                        </tr>`;
                                        tabla.innerHTML += fila;
            });
        }

                                        document.getElementById("productoForm").addEventListener("submit", agregarProducto);
                                    </script>

                                </body>
                                </html>

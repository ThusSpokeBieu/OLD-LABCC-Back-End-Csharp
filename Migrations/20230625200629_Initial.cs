using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LABCC.BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "VO");

            migrationBuilder.EnsureSchema(
                name: "Entity");

            migrationBuilder.CreateTable(
                name: "Generos",
                schema: "VO",
                columns: table => new
                {
                    Letter = table.Column<string>(type: "char(1)", nullable: false, comment: "É a letra que representa o gênero."),
                    Value = table.Column<string>(type: "varchar(18)", maxLength: 18, nullable: false, comment: "É o nome do gênero."),
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                schema: "VO",
                columns: table => new
                {
                    Value = table.Column<string>(type: "varchar(18)", maxLength: 18, nullable: false, comment: "É o valor do status."),
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposDeUsuario",
                schema: "VO",
                columns: table => new
                {
                    Sigla = table.Column<string>(type: "varchar(18)", nullable: false, comment: "É a sigla que representa o tipo de usuário."),
                    Value = table.Column<string>(type: "varchar(18)", maxLength: 18, nullable: false, comment: "É o nome do tipo de usuário."),
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDeUsuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Identificador do usuário")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CpfOuCnpj = table.Column<string>(type: "varchar(18)", maxLength: 18, nullable: false, comment: "É o documento do usuário (CPF ou CNPJ), apenas digitos numéricos."),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Email do usuário"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Nome do usuário"),
                    DataDeNascimento = table.Column<DateTime>(type: "date", nullable: false, comment: "Data de Nascimento do usuário"),
                    Telefone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false, comment: "Telefone do usuário"),
                    GeneroId = table.Column<byte>(type: "tinyint", nullable: false, comment: "Gênero do usuário: 1 - Masculino, 2 - Feminino, 3 - Outro"),
                    TipoDeUsuarioId = table.Column<byte>(type: "tinyint", nullable: false, comment: "Tipo do usuário: 1 - Administrador, 2 - Gerente, 3 - Criador, 4 - Outro"),
                    AtualizadoEm = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSUTCDATETIME()", comment: "Momento em que o usuário foi atualizado"),
                    CriadoEm = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSUTCDATETIME()", comment: "Momento em que o usuário foi criado"),
                    StatusId = table.Column<byte>(type: "tinyint", nullable: false, comment: "Status do usuário: 0 - Inativo, 1 - Ativo")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Generos_GeneroId",
                        column: x => x.GeneroId,
                        principalSchema: "VO",
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_Status_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "VO",
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_TiposDeUsuario_TipoDeUsuarioId",
                        column: x => x.TipoDeUsuarioId,
                        principalSchema: "VO",
                        principalTable: "TiposDeUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "VO",
                table: "Generos",
                columns: new[] { "Id", "Letter", "Value" },
                values: new object[,]
                {
                    { (byte)1, "M", "Masculino" },
                    { (byte)2, "F", "Feminino" },
                    { (byte)3, "O", "Outro" }
                });

            migrationBuilder.InsertData(
                schema: "VO",
                table: "Status",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { (byte)0, "Inativo" },
                    { (byte)1, "Ativo" }
                });

            migrationBuilder.InsertData(
                schema: "VO",
                table: "TiposDeUsuario",
                columns: new[] { "Id", "Sigla", "Value" },
                values: new object[,]
                {
                    { (byte)1, "ADM", "Administrador" },
                    { (byte)2, "GRT", "Gerente" },
                    { (byte)3, "CRD", "Criador" },
                    { (byte)4, "OTR", "Outro" }
                });

            migrationBuilder.InsertData(
                schema: "Entity",
                table: "Usuarios",
                columns: new[] { "Id", "CpfOuCnpj", "DataDeNascimento", "Email", "GeneroId", "Nome", "StatusId", "Telefone", "TipoDeUsuarioId" },
                values: new object[,]
                {
                    { 1L, "278.656.291-09", new DateTime(2000, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "lucas_diego@gimail.com", (byte)1, "Lucas Diego Santos", (byte)1, "(63) 99729-3374", (byte)1 },
                    { 2L, "121.682.363-48", new DateTime(2001, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "marcos.mateus.campos@doublesp.com.br", (byte)1, "Marcos Mateus Anthony Campos", (byte)1, "(75) 99404-5248", (byte)4 },
                    { 3L, "493.617.515-30", new DateTime(1954, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "mirella_beatriz_lima@engeseg.com.br", (byte)2, "Mirella Beatriz Lima", (byte)1, "(62) 98420-9876", (byte)1 },
                    { 4L, "864.306.046-16", new DateTime(1996, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "antonio_carlos_dias@lukin4.com.br", (byte)3, "Antonio Carlos Eduardo Dias", (byte)0, "(65) 99579-0748", (byte)2 },
                    { 5L, "945.981.184-15", new DateTime(1998, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "kamilly.antonia.almeida@onset.com.br", (byte)2, "Kamilly Antônia Almeida", (byte)1, "(93) 98644-1270", (byte)3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Generos_Letter",
                schema: "VO",
                table: "Generos",
                column: "Letter",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Generos_Value",
                schema: "VO",
                table: "Generos",
                column: "Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Status_Value",
                schema: "VO",
                table: "Status",
                column: "Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TiposDeUsuario_Sigla",
                schema: "VO",
                table: "TiposDeUsuario",
                column: "Sigla",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TiposDeUsuario_Value",
                schema: "VO",
                table: "TiposDeUsuario",
                column: "Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CpfOuCnpj",
                schema: "Entity",
                table: "Usuarios",
                column: "CpfOuCnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                schema: "Entity",
                table: "Usuarios",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_GeneroId",
                schema: "Entity",
                table: "Usuarios",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Nome",
                schema: "Entity",
                table: "Usuarios",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_StatusId",
                schema: "Entity",
                table: "Usuarios",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TipoDeUsuarioId",
                schema: "Entity",
                table: "Usuarios",
                column: "TipoDeUsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "Generos",
                schema: "VO");

            migrationBuilder.DropTable(
                name: "Status",
                schema: "VO");

            migrationBuilder.DropTable(
                name: "TiposDeUsuario",
                schema: "VO");
        }
    }
}

#  Morrigan — 2D Platformer (Unity Study)

<p align="center">
  <em>Projeto acadêmico de desenvolvimento de jogo de plataforma 2D — UTFPR</em>
</p>

---

##  Sobre o Projeto

**Morrigan** é um projeto de estudo desenvolvido na **P1 da disciplina de Desenvolvimento de Jogos** da **UTFPR (Universidade Tecnológica Federal do Paraná)**.

O foco do projeto é a implementação de mecânicas fundamentais de um jogo de plataforma 2D utilizando a Unity, incluindo:

*  Controle de movimento do player
*  Sistema de colisão e física
*  Interação entre Player e NPCs
*  Sistema de animações
*  Estrutura de scripts e lógica de gameplay

>  Projeto em estado de **protótipo**, com fins educacionais.

---

##  Versão jogável

A versão executável do projeto (protótipo) pode ser acessada através do link disponível na seção **About** deste repositório (Itch.io).

---

##  Preview

<p align="center">
  <!-- Substitua pelos caminhos reais -->
  <img src="(https://github.com/muvucka/unity-gamesDev-utfpr/blob/main/public/menu.png)" width="600" border-radiu="50px"/>
  <img src="(https://github.com/muvucka/unity-gamesDev-utfpr/blob/main/public/frame.png)" width="600" border-radiu="50px"/>
  <img src="(https://github.com/muvucka/unity-gamesDev-utfpr/blob/main/public/frame-move.png)" width="600" border-radiu="50px"/>
  <img src="(https://github.com/muvucka/unity-gamesDev-utfpr/blob/main/public/frame-dash.png)" width="600" border-radiu="50px"/>
  <img src="(https://github.com/muvucka/unity-gamesDev-utfpr/blob/main/public/frame-spike.png)" width="600" border-radiu="50px"/>
  <img src="(https://github.com/muvucka/unity-gamesDev-utfpr/blob/main/public/frame-soco.png)" width="600" border-radiu="50px"/>
  <img src="(https://github.com/muvucka/unity-gamesDev-utfpr/blob/main/public/frame-dano.png)" width="600" border-radiu="50px"/>
</p>

---

##  Como abrir o projeto na Unity

###  Pré-requisitos

* Unity Hub instalado
* Versão da Unity compatível (recomendado usar a mesma versão do projeto)

---

###  1. Clonar o repositório

```bash
git clone https://github.com/seu-usuario/seu-repo.git
```

Ou baixar o `.zip` e extrair.

---

###  2. Abrir no Unity Hub

1. Abra o **Unity Hub**
2. Clique em **"Open"**
3. Selecione a pasta raiz do projeto (onde estão):

   ```
   Assets/
   ProjectSettings/
   Packages/
   ```

---

###  3. Configurações importantes

Após abrir o projeto:

* Aguarde o Unity importar os assets
* Caso solicitado, aceite instalar dependências

Recomenda-se verificar:

* **Edit → Project Settings → Editor**

  * Version Control: `Visible Meta Files`
  * Asset Serialization: `Force Text`

---

##  Como rodar o projeto (modo desenvolvimento)

1. Abra a cena principal em:

```
Assets/Scenes/
```

2. Clique em **Play (▶)** no topo da Unity

---

##  Estrutura do Projeto

```plaintext
Assets/
 ├── Scripts/        # Lógica do jogo (movimento, NPC, etc)
 ├── Animations/     # Animações do player/NPC
 ├── Sprites/        # Assets visuais
 ├── Scenes/         # Cenas do jogo
 └── Prefabs/        # Objetos reutilizáveis
```

---

##  Lógica do Jogo

###  Player

Scripts responsáveis por:

* movimentação horizontal
* pulo
* aplicação de física (Rigidbody2D)

---

###  NPCs

Sistema de interação baseado em:

* colisões (OnCollision / OnTrigger)
* lógica de comportamento definida em scripts

---

### Mecânicas principais

* Detecção de colisão com cenário
* Interação com entidades
* Sistema básico de animação por estados

---

## Como modificar o projeto

Você pode:

* Alterar variáveis diretamente nos scripts (`Assets/Scripts`)
* Ajustar comportamento via **Inspector**
* Modificar animações no **Animator**
* Editar cenas no editor da Unity

---

##  Contexto Acadêmico

Projeto desenvolvido para a disciplina de:

> **Desenvolvimento de Jogos**
> Universidade Tecnológica Federal do Paraná (UTFPR)

---

##  Autor

**Wilson Santos**

---

##  Licença

Projeto com fins **educacionais**.

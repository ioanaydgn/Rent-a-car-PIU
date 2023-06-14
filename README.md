# Rent-a-car-PIU
# **Documentația de aplicare a agenției de închiriere auto**

## **Intrare**

Această documentație explică utilizarea și caracteristicile cheie ale unei aplicații simple de agenție de închiriere de mașini. Această aplicație este dezvoltată pentru a gestiona închirierea mașinilor clienților.

## **Interfața cu utilizatorul**

Aplicația include interfața cu utilizatorul cu următoarele caracteristici cheie:

1. Acasă:
    - Oferă un formular de conectare pentru înregistrarea clientului sau autentificare.
    - Oferă informații despre vehiculele disponibile.
2. Înregistrarea clientului:
    - Oferă un formular de înregistrare pentru noi clienți să se înscrie.
    - Poate fi necesar să introduceți în formular informații precum numele utilizatorului, adresa de e-mail, numărul de telefon.
3. Introducere:
    - Oferă un formular de conectare pentru ca clienții înregistrați să se autentifice.
    - Conectarea poate necesita acreditări, cum ar fi numele de utilizator sau e-mailul și parola.
4. Pagina Instrumente:
    - Oferă utilizatorilor o listă pentru a vedea vehiculele disponibile.
    - Pentru fiecare vehicul, pot fi afișate informații precum marca, modelul, anul, tipul de combustibil, taxa zilnică de închiriere.
    - Clienții pot face clic pe un link pentru a vedea detaliile vehiculelor și pot trimite o cerere pentru procesul de închiriere.
5. Pagina cu detaliile vehiculului:
    - Afișează detaliile unui vehicul selectat.
    - Detaliile pot include fotografii ale vehiculului, specificații tehnice și taxa zilnică de închiriere.
    - Clienții pot completa un formular pentru a trimite o cerere de închiriere a vehiculului. În formular, pot fi solicitate informații precum data și durata închirierii.
6. Pagina de cereri de închiriere:
    - Enumeră cererile de închiriere trimise de clienți.
    - Pentru fiecare cerere, pot fi afișate detaliile vehiculului și starea solicitării (aprobată, respinsă sau în așteptare).

## **Structura bazei de date**

Aplicația include următoarele structuri de bază de baze de date:

1. Tabel clienți:
    - Nume Prenume
    - CNP
2. Diagrama vehiculului:
    - Marca
    - model
    - Caracteristici
    - Taxa zilnica de inchiriere
3. Tabel cu cereri de închiriere:
    - ID client (link către Tabelul clienți)
    - ID vehicul (link către diagrama vehiculului)
    - Data închirierii
    - Perioada de inchiriere

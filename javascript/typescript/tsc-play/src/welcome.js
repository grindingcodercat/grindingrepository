function welcome(name) {
    if (name === null) {
        return "Welcome!";
    }
    return "Welcome, ".concat(name, "!");
}

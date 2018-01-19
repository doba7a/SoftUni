function Calculator(leftOperand, operator, rightOperand) {
    this.leftOperand = leftOperand;
    this.operator = operator;
    this.rightOperand = rightOperand;

    this.calculateResult = function () {
        let result = 0;

        if (this.operator === "+"){
            result = this.leftOperand + this.rightOperand;
        }
        else if (this.operator === "-"){
            result = this.leftOperand - this.rightOperand;
        }
        else if (this.operator === "*"){
            result = this.leftOperand * this.rightOperand;
        }
        else if (this.operator === "/"){
            result = this.leftOperand / this.rightOperand;
        }
        else if (this.operator === "^"){
            result = Math.pow(this.leftOperand, this.rightOperand);
        }
        else if (this.operator === "√"){
            result = Math.pow(this.rightOperand, 1 / this.leftOperand);
        }

        return result;
    }
}

module.exports = Calculator;
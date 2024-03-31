**What code smells did you see?**

1. Long Method: The `Register` method is too complex.
2. Comments: There are commented-out code blocks within the method.
3. Magic Numbers: Hardcoded numbers like `10`, `3`, `0`, etc., are used without clear meaning.
4. Deep Nesting: Multiple levels of nested `if` statements.
5. Complex Conditions: Conditions for determining if a speaker is "good" or if sessions are approved are complex.
6. Violation of Single Responsibility Principle (SRP): The `Speaker` class is responsible for both representing a speaker and handling speaker registration logic.
7. Improper Names: variables do not have clear names.

**What problems do you think the Speaker class has?**

1. Complex and Lengthy Method: The `Register` method is difficult to understand and maintain due to its length and complexity.
2. Lack of Clarity: Magic numbers and complex conditions make the code less readable and maintainable.
3. Violation of SRP: The `Speaker` class has multiple responsibilities, violating the SRP.

**Which clean code principles (or general programming principles) did it violate?**

1. Single Responsibility Principle (SRP): The `Speaker` class violates SRP by handling both speaker representation and registration logic.
2. Open Closed Principle (OCP): List of technologies are listed directly in the class.
3. Comments: Self-explanatory codes don't require comments.
4. Meaningful Names: variables do not have clear names.
5. KISS: Code is too complex.
6. YAGNI: Commented unused code.
7. Readability: The code is hard to read due to long methods, deep nesting, and lack of clarity in variable names and conditions.
8. Maintainability: The complex and lengthy method makes the code difficult to maintain and extend.

**What refactoring techniques did you use?**

1. Formed distinct groups of classes.
2. Divided the `Register` method and moved the functionality in separate classes.
3. Created different types of model.
4. Created classes responsible for validation, interaction with modes...
5. Reduced the complexity.
6. Get rid of unused chunks of code.

# Usage
```bash
# compile the PSrc, PSpec and PTst
p compile 

# model check the P model against the PSpec.
# the specific spec/property must be declared via assert in PTst
p check  

# model check specific test cases
p check -tc <test-case>
```
# FAQ
## Overwhemling amount of errors
- try deleting the `PGenerated/` directory and retry again.


## Error: Failed to get test method ""
- Detailed Error: `Error: Failed to get test method '' from assembly 'Hello, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'`
    - reinstall or update the p programming language

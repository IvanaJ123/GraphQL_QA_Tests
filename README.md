# GraphQL_QA_Tests
Automated testing of the [GraphQLZero API](https://graphqlzero.almansi.me/) using **Jest** in Node.js.  
Includes real API testing, mocked tests, and a CI/CD workflow with GitHub Actions.



Installation

1. Clone the repository:

```bash
git clone https://github.com/IvanaJ123/GraphQL_QA_Tests.git
cd GraphQL_QA_Tests

Install dependencies:
npm install


> Running Tests
Real API Tests:
Connects to the live GraphQLZero API

Mocked Tests:
Uses mocked GraphQL requests to safely test:
npx jest --verbose


> Notes

Testing Framework: Jest
GraphQL Client: tests/helpers/graphqlClient.js
Mocked Requests: tests/__mocks__/graphqlClient.js

Real and mocked tests are separated for clarity.
✅ All tests cover queries, mutations, and error handling.

Demonstrates integration of automated tests into a CI/CD pipeline.


> CI/CD Integration

GitHub Actions workflow located at .github/workflows/ci.yml.
Automatically runs tests on every push or pull request to the master branch.

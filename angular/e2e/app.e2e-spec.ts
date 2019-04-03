import { TestProjectTemplatePage } from './app.po';

describe('TestProject App', function() {
  let page: TestProjectTemplatePage;

  beforeEach(() => {
    page = new TestProjectTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});

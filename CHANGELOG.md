# Changelog

## 0.1.0 (2026-05-09)

Full Changelog: [v0.0.1...v0.1.0](https://github.com/phoebe-bird/phoebe-csharp/compare/v0.0.1...v0.1.0)

### ⚠ BREAKING CHANGES

* **client:** change casing of some identifiers
* **client:** **Migration:** Only use all-caps in PascalCase for two-letter acronyms. Otherwise, use a capital letter for the first letter and lowercase letters for the rest.
* **client:** add pagination
* **client:** use readonly types for properties

### Features

* **api:** manual updates ([42bf4b1](https://github.com/phoebe-bird/phoebe-csharp/commit/42bf4b13a9c71ece5aa4996331fd0267cd2a87f5))
* **client:** add `ToString` and `Equals` methods ([56e0ec9](https://github.com/phoebe-bird/phoebe-csharp/commit/56e0ec9b758f4474ceda45d34a0fc79f19a489ae))
* **client:** add `ToString` to `ApiEnum` ([bc1aa27](https://github.com/phoebe-bird/phoebe-csharp/commit/bc1aa27686af5f5e96da3f98ef9a6d9b5d96b87b))
* **client:** add EnvironmentUrl ([7973767](https://github.com/phoebe-bird/phoebe-csharp/commit/7973767896dd842b5a0d5f548e7738614974ceb0))
* **client:** add Equals and ToString to params ([bf0532f](https://github.com/phoebe-bird/phoebe-csharp/commit/bf0532f38c14a1c21c1d5337490ccfabd4569b96))
* **client:** add helper functions for raw messages ([1a1f01d](https://github.com/phoebe-bird/phoebe-csharp/commit/1a1f01de6cf4da4067db21b99644ab17e2627ec5))
* **client:** add more `ToString` implementations ([82d1d1f](https://github.com/phoebe-bird/phoebe-csharp/commit/82d1d1f0eab3adc238910a5fb11f6baa27516d7f))
* **client:** add multipart form data support ([6c08c6b](https://github.com/phoebe-bird/phoebe-csharp/commit/6c08c6ba0f93f3bc6a6b668cd471317ff6c22293))
* **client:** add pagination ([f7a02d6](https://github.com/phoebe-bird/phoebe-csharp/commit/f7a02d641fec96689a25d239045d3a0396824917))
* **client:** add x-stainless-retry-count ([0b39970](https://github.com/phoebe-bird/phoebe-csharp/commit/0b39970cc8a67876d9f3b67f7889755be3338101))
* **client:** improve csproj ([abc8a69](https://github.com/phoebe-bird/phoebe-csharp/commit/abc8a69e745331ac4bc8c1643115889ae14f4e8d))
* **client:** support .NET Standard 2.0 ([b652c94](https://github.com/phoebe-bird/phoebe-csharp/commit/b652c94896a217a7dce7d0b090c23906721c9f38))
* **client:** support accessing raw responses ([4ebd8e2](https://github.com/phoebe-bird/phoebe-csharp/commit/4ebd8e25b0a271f7b6f415454ae26aeb9670a60e))
* **internal:** add additional object tests ([7961264](https://github.com/phoebe-bird/phoebe-csharp/commit/79612644ebc0d95b025c6ea9373cac61e7defaa6))


### Bug Fixes

* **ci:** don't throw an error about missing lsof ([fe625ab](https://github.com/phoebe-bird/phoebe-csharp/commit/fe625abb16fedc51ac206f9d2417666177ae16ea))
* **ci:** run tests properly on windows ([1fa0d76](https://github.com/phoebe-bird/phoebe-csharp/commit/1fa0d7601d205684cebaafe9d81d5e29a31e494d))
* **client:** add missing `.Value` ([6fbfbec](https://github.com/phoebe-bird/phoebe-csharp/commit/6fbfbec7c02accf5f982fc3b9649c817b6339a2c))
* **client:** add missing null check ([1f282dc](https://github.com/phoebe-bird/phoebe-csharp/commit/1f282dcbca2da404f9d6b9156316af508b34ca3a))
* **client:** check response status when `MaxRetries = 0` ([477e0d5](https://github.com/phoebe-bird/phoebe-csharp/commit/477e0d560af5251221a1706f62cb3379e89e734d))
* **client:** copy path params in params copy constructors ([dd7ac78](https://github.com/phoebe-bird/phoebe-csharp/commit/dd7ac78eb8058dc9084f59d92c830fbfa1fb5f63))
* **client:** correct enum serialization in path ([af9393e](https://github.com/phoebe-bird/phoebe-csharp/commit/af9393e16c82d3c152f17fed4ce5406d8290dbef))
* **client:** ensure deep immutability for deep array/dict structures ([6967631](https://github.com/phoebe-bird/phoebe-csharp/commit/69676318d3c3d660060cbcd6ea93bd16f0b902bc))
* **client:** fix type mismatch for nested readonly types ([dc147d1](https://github.com/phoebe-bird/phoebe-csharp/commit/dc147d1c2b453055e8e03196d6b5f3a038083a1d))
* **client:** freeze models on property access ([f5b3516](https://github.com/phoebe-bird/phoebe-csharp/commit/f5b35165177aaa3853db3d2ab83fa7ce57c63dec))
* **client:** handle floats correctly ([e42a7f2](https://github.com/phoebe-bird/phoebe-csharp/commit/e42a7f20574a50ec82b29fd769f94d9eb7a57022))
* **client:** handling of null value type ([9656f40](https://github.com/phoebe-bird/phoebe-csharp/commit/9656f40d245662e61cbb6d9fe2076246d314e65f))
* **client:** incorrect variable reference ([50ff823](https://github.com/phoebe-bird/phoebe-csharp/commit/50ff823261a2a1ed506540a52c055fb6e8590072))
* **client:** throw api enum errors as invalid data exception ([629e1eb](https://github.com/phoebe-bird/phoebe-csharp/commit/629e1eba1880d8f1a4e658417eace6a9a5951876))
* **client:** use readonly types for properties ([2cb943c](https://github.com/phoebe-bird/phoebe-csharp/commit/2cb943c2b153c7237fe5d66504e3781d2bf61a77))
* **client:** with expressions for models ([36f5f76](https://github.com/phoebe-bird/phoebe-csharp/commit/36f5f7609070703c1a15778098eeca283579c863))
* **internal:** add nullability checks for tests ([05eab8f](https://github.com/phoebe-bird/phoebe-csharp/commit/05eab8ff38247e59428a6527f9f708b190ffb0d4))
* **internal:** remove redundant line ([ce55bcd](https://github.com/phoebe-bird/phoebe-csharp/commit/ce55bcdcb2d1de134e58ab818a41de0c0b16b554))
* **internal:** remove roundtrip tests for multipart params ([90a1722](https://github.com/phoebe-bird/phoebe-csharp/commit/90a1722e12652058d39883788640a172c6cf7d01))
* **internal:** running net462 tests on ci ([f2d388f](https://github.com/phoebe-bird/phoebe-csharp/commit/f2d388f2897e37d7006b859f28b9ce55d8db6504))
* **internal:** test nullability warnings ([b606fc5](https://github.com/phoebe-bird/phoebe-csharp/commit/b606fc5bac39d920571396abcb32eb188d6b3ac9))


### Performance Improvements

* **client:** add json deserialization caching ([6967631](https://github.com/phoebe-bird/phoebe-csharp/commit/69676318d3c3d660060cbcd6ea93bd16f0b902bc))
* **client:** use async deserialization in `HttpResponse` ([e76e7a4](https://github.com/phoebe-bird/phoebe-csharp/commit/e76e7a4fb3edcc5eb8727c3340c377134a936040))


### Chores

* change visibility of QueryString() and AddDefaultHeaders ([7099fa2](https://github.com/phoebe-bird/phoebe-csharp/commit/7099fa293d3c152f88759bc4a3266f8fa210e2c6))
* **client:** consistently use serializer options ([c081409](https://github.com/phoebe-bird/phoebe-csharp/commit/c0814092fe312dfe9bb3d5fa12b7474779969960))
* **client:** improve object instantiation ([3fe3a2d](https://github.com/phoebe-bird/phoebe-csharp/commit/3fe3a2dd5963c8e54a4368bcb22da2d58983d198))
* **client:** update namespace imports ([82e74ca](https://github.com/phoebe-bird/phoebe-csharp/commit/82e74caf36aeaa8e6df7911363cb7658b00588fb))
* **client:** update test dependencies ([3f4c2e7](https://github.com/phoebe-bird/phoebe-csharp/commit/3f4c2e7a5ba5ef62a9cf9a95ea2bfd8e9dc0b150))
* configure new SDK language ([41cf67a](https://github.com/phoebe-bird/phoebe-csharp/commit/41cf67ab7dc1ef126f948e231d132b0b8a7b6cc7))
* **internal:** add copy constructor tests ([51bbb3b](https://github.com/phoebe-bird/phoebe-csharp/commit/51bbb3b7949f383cdd61d66124acb2b297dbbf44))
* **internal:** add enum tests ([2f6c034](https://github.com/phoebe-bird/phoebe-csharp/commit/2f6c0343bc8c3fe6e94664ca352e501b6b0186f4))
* **internal:** add files to sln so they show up in visual studio ([bfb3949](https://github.com/phoebe-bird/phoebe-csharp/commit/bfb3949ad4c30da73a9001f868a0ca6df4d1f959))
* **internal:** codegen related update ([a7382f7](https://github.com/phoebe-bird/phoebe-csharp/commit/a7382f79679ee88b0ba56cb60648b91c40816655))
* **internal:** codegen related update ([25600be](https://github.com/phoebe-bird/phoebe-csharp/commit/25600bea680df794f13836deb6c465f8b00bd36a))
* **internal:** codegen related update ([501286f](https://github.com/phoebe-bird/phoebe-csharp/commit/501286f1be0440236114d138a5d6745ddf809b9b))
* **internal:** codegen related update ([48781f9](https://github.com/phoebe-bird/phoebe-csharp/commit/48781f9861cbef658edcbb49c8b84a439a599bc9))
* **internal:** codegen related update ([1e0bd8f](https://github.com/phoebe-bird/phoebe-csharp/commit/1e0bd8f7524765199efe3f5d6a8f9097168559b7))
* **internal:** codegen related update ([234a138](https://github.com/phoebe-bird/phoebe-csharp/commit/234a1388b410f26e06c2b7b077b49331120e1e90))
* **internal:** codegen related update ([15d2bd2](https://github.com/phoebe-bird/phoebe-csharp/commit/15d2bd26cf40d82f5c6e5910549117b08ed76877))
* **internal:** codegen related update ([39033c1](https://github.com/phoebe-bird/phoebe-csharp/commit/39033c1f61471866a0a2b2c074d4167564376a93))
* **internal:** codegen related update ([f00c31b](https://github.com/phoebe-bird/phoebe-csharp/commit/f00c31b23585fd9c5512533454a8c435e97dfb96))
* **internal:** codegen related update ([ec509ca](https://github.com/phoebe-bird/phoebe-csharp/commit/ec509cafa7a5dbf40cc2fbd463016e36630d71d5))
* **internal:** codegen related update ([e627131](https://github.com/phoebe-bird/phoebe-csharp/commit/e627131eac7dce0d165a7d29bdd8569a2384ce9c))
* **internal:** codegen related update ([5c0d7ef](https://github.com/phoebe-bird/phoebe-csharp/commit/5c0d7effeee3c6f08727fa6b18430a20ee0e821e))
* **internal:** codegen related update ([a17bfa2](https://github.com/phoebe-bird/phoebe-csharp/commit/a17bfa22b98190b33d9823519c917a95920bca57))
* **internal:** codegen related update ([e9a4ef5](https://github.com/phoebe-bird/phoebe-csharp/commit/e9a4ef51afd0762bf4b621dc247825493768e23d))
* **internal:** codegen related update ([33a1428](https://github.com/phoebe-bird/phoebe-csharp/commit/33a1428b4c01f91fab1d9ad7778d8774e551754b))
* **internal:** codegen related update ([0c99e7a](https://github.com/phoebe-bird/phoebe-csharp/commit/0c99e7a8f99be6f61ff229c9847555f580ff0bdf))
* **internal:** codegen related update ([de72761](https://github.com/phoebe-bird/phoebe-csharp/commit/de72761e2e81889bf31c169544e19778915cade7))
* **internal:** codegen related update ([2d683a9](https://github.com/phoebe-bird/phoebe-csharp/commit/2d683a9ae271ab4504befed870202c5407f9e66c))
* **internal:** codegen related update ([2e1a752](https://github.com/phoebe-bird/phoebe-csharp/commit/2e1a752e95e213265193dacf202ae05c71f7a16e))
* **internal:** codegen related update ([71d4b10](https://github.com/phoebe-bird/phoebe-csharp/commit/71d4b105aefd362136cbce68dac6c0e05fad7eb3))
* **internal:** codegen related update ([584de75](https://github.com/phoebe-bird/phoebe-csharp/commit/584de75d8607d62faae6e473fd4d70b552c2b482))
* **internal:** codegen related update ([53fc1d1](https://github.com/phoebe-bird/phoebe-csharp/commit/53fc1d1957f118d3d96ec99f035a8d7aae0824a0))
* **internal:** codegen related update ([0ee6e7e](https://github.com/phoebe-bird/phoebe-csharp/commit/0ee6e7e2f7e46dfe4d910c5a6d69f003de283479))
* **internal:** codegen related update ([ca75656](https://github.com/phoebe-bird/phoebe-csharp/commit/ca7565602f75f4ed448cb2d88aa5d0fd73f6a34a))
* **internal:** equality and more unit tests ([89529f3](https://github.com/phoebe-bird/phoebe-csharp/commit/89529f3fda2cfcb4fa90dd0f62c9dd0de79844d0))
* **internal:** remove redundant keyword ([6ba9631](https://github.com/phoebe-bird/phoebe-csharp/commit/6ba96310b1e65046b32052db766db68eeed6b838))
* **internal:** share csproj properties with dir build props ([b606fc5](https://github.com/phoebe-bird/phoebe-csharp/commit/b606fc5bac39d920571396abcb32eb188d6b3ac9))
* **internal:** simplify imports ([332730a](https://github.com/phoebe-bird/phoebe-csharp/commit/332730a1eef66b09286e7369b91eb2ec3da688b5))
* **internal:** suppress a diagnostic ([b5d9447](https://github.com/phoebe-bird/phoebe-csharp/commit/b5d9447cb5dc9424d30a3958176e2f7376e1265a))
* **internal:** suppress diagnostic for .netstandard2.0 ([ad2b2e0](https://github.com/phoebe-bird/phoebe-csharp/commit/ad2b2e0208ae4ee42b8ea6ce191f15d65b26c0bd))
* **internal:** turn off overzealous lints ([2a7aede](https://github.com/phoebe-bird/phoebe-csharp/commit/2a7aede410598a4f8f81d613421364e8790316b0))
* **internal:** update `actions/checkout` version ([235903f](https://github.com/phoebe-bird/phoebe-csharp/commit/235903fa950f7cae330d283b91297f5482e2197c))
* **internal:** update csproj formatting ([5c2406f](https://github.com/phoebe-bird/phoebe-csharp/commit/5c2406f5bf56b33fe777ca8daa408b9c0b8c5150))
* **internal:** use `Random.Shared` in newer .NET versions ([10ad1df](https://github.com/phoebe-bird/phoebe-csharp/commit/10ad1dfa3fc46cde7f09e6d5ceb6e2b65ef80073))
* **internal:** use better test examples ([b606fc5](https://github.com/phoebe-bird/phoebe-csharp/commit/b606fc5bac39d920571396abcb32eb188d6b3ac9))
* **readme:** remove beta warning now that we're in ga ([af2ad81](https://github.com/phoebe-bird/phoebe-csharp/commit/af2ad81a65f5ad989b26c61592e06cd5208116a5))


### Documentation

* add contributing.md ([f1c7d85](https://github.com/phoebe-bird/phoebe-csharp/commit/f1c7d85df552e5d31d1cbeab11f04d2538d97a3b))
* add more comments ([59ec33e](https://github.com/phoebe-bird/phoebe-csharp/commit/59ec33ea8978f361c85523741a5bb46b93eb0e03))
* add more comments ([e54de29](https://github.com/phoebe-bird/phoebe-csharp/commit/e54de29ddd92f023487f7c52735606936717cb76))
* add raw responses to readme ([41dd17c](https://github.com/phoebe-bird/phoebe-csharp/commit/41dd17c750fea4b11c4b4254ac192e54cb7f1238))


### Refactors

* **client:** add `JsonDictionary` identity methods ([360e5e7](https://github.com/phoebe-bird/phoebe-csharp/commit/360e5e7f2c9ff0e26018688b72ab531b397b08a9))
* **client:** change casing of some identifiers ([27317a4](https://github.com/phoebe-bird/phoebe-csharp/commit/27317a4d26be9b2734237d9645a2b3d6bc3d4b90))
* **client:** make unions implement `ModelBase` ([505d17c](https://github.com/phoebe-bird/phoebe-csharp/commit/505d17c56fe362b4d81a7837d11cd8b889e134e0))
* **internal:** `JsonElement` constant construction ([d9af368](https://github.com/phoebe-bird/phoebe-csharp/commit/d9af368da9dd6ece310f488fecd2c3179cb8edf6))
* **internal:** share get/set logic ([9656f40](https://github.com/phoebe-bird/phoebe-csharp/commit/9656f40d245662e61cbb6d9fe2076246d314e65f))
